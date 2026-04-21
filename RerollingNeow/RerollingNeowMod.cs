using System.Collections.Generic;
using System.Linq;
using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes;
using MegaCrit.Sts2.Core.Nodes.Audio;
using MegaCrit.Sts2.Core.Runs;
using MegaCrit.Sts2.Core.Saves;

namespace RerollingNeow;

internal static class Log
{
    private static readonly string LogPath = System.IO.Path.Combine(
        OS.GetUserDataDir(), "logs", "RerollingNeow.log");

    private static bool _cleared;

    public static void Write(string message)
    {
        try
        {
            if (!_cleared)
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(LogPath)!);
                System.IO.File.WriteAllText(LogPath,
                    $"[{System.DateTime.Now:HH:mm:ss.fff}] === Log cleared (new session) ==={System.Environment.NewLine}");
                _cleared = true;
            }
            var line = $"[{System.DateTime.Now:HH:mm:ss.fff}] {message}{System.Environment.NewLine}";
            System.IO.File.AppendAllText(LogPath, line);
            GD.Print($"[RerollingNeow] {message}");
        }
        catch { }
    }
}

[ModInitializer("Initialize")]
public static class RerollingNeowMod
{
    private static bool _isRerolling;

    public static void Initialize()
    {
        var harmony = new Harmony("com.rerollingneow.sts2");
        harmony.PatchAll(typeof(RerollingNeowMod).Assembly);
        Log.Write("RerollingNeow mod initialized — press F4 to reroll with a new seed");
    }

    /// <summary>
    /// Reroll: capture current run settings, return to main menu via the game's
    /// own cleanup path, then immediately start a brand-new run with a fresh seed.
    /// </summary>
    public static async Task DoReroll()
    {
        if (_isRerolling)
            return;

        var runManager = RunManager.Instance;
        if (runManager is not { IsInProgress: true })
            return;

        _isRerolling = true;
        Log.Write("=== Reroll triggered ===");
        try
        {
            // 1. Capture current run settings before any cleanup.
            //    Character, Acts, Modifiers are model-registry singletons that
            //    survive run cleanup; copy the lists to be safe.
            var currentState = runManager.DebugOnlyGetState();
            if (currentState == null)
            {
                Log.Write("Could not get current run state, aborting");
                return;
            }

            var character = currentState.Players[0].Character;
            var ascensionLevel = currentState.AscensionLevel;
            var gameMode = currentState.GameMode;
            // StartNewSingleplayerRun calls ToMutable() on each act, which
            // requires canonical (non-mutable) model instances.  RunState's
            // acts are mutable copies, so we resolve back to the originals.
            var acts = currentState.Acts
                .Select(a => a.CanonicalInstance)
                .ToList() as IReadOnlyList<ActModel>;
            var modifiers = currentState.Modifiers.ToList() as IReadOnlyList<ModifierModel>;
            Log.Write($"Captured: A{ascensionLevel} mode={gameMode}");

            // 2. Return to main menu — the game properly tears down the run,
            //    cleans up all scenes/nodes, and transitions back to menu state.
            await NGame.Instance.ReturnToMainMenu();
            Log.Write("Returned to main menu");

            // 3. Delete old run save so it doesn't linger.
            try
            {
                SaveManager.Instance.DeleteCurrentRun();
                Log.Write("Deleted old run save");
            }
            catch (Exception ex)
            {
                Log.Write($"Save delete (non-fatal): {ex.Message}");
            }

            // 4. Start a brand new run with a fresh random seed.
            //    This is the same path the main menu's "New Run" button uses.
            var newSeed = new System.Random().Next(1, 999999999).ToString();
            Log.Write($"Starting new run with seed: {newSeed}");

            await NGame.Instance.StartNewSingleplayerRun(
                character, true, acts, modifiers, newSeed, gameMode, ascensionLevel, null);

            Log.Write("=== Reroll complete ===");
        }
        catch (Exception ex)
        {
            Log.Write($"Reroll error: {ex.Message}\n{ex.StackTrace}");
        }
        finally
        {
            _isRerolling = false;
        }
    }
}

/// <summary>
/// Intercept F4 key press to trigger the reroll.
/// </summary>
[HarmonyPatch(typeof(NGame), "_Input")]
public static class PatchNGameInput
{
    [HarmonyPrefix]
    public static void Prefix(InputEvent inputEvent)
    {
        if (inputEvent is InputEventKey { Pressed: true } key
            && key.Keycode == Key.F4
            && !key.Echo
            && RunManager.Instance?.IsInProgress == true
            && RunManager.Instance?.IsGameOver != true
            && !NGame.Instance.Transition.InTransition)
        {
            TaskHelper.RunSafely(RerollingNeowMod.DoReroll());
        }
    }
}
