# Rerolling Neow

**Slay the Spire 2 Mod** — Press **F4** to instantly start a new run with a fresh seed.

[한국어](#한국어) | [English](#english) | [简体中文](#简体中文) | [繁體中文](#繁體中文) | [日本語](#日本語)

---

## 한국어

### 소개

런 도중 아무 때나 **F4** 키를 누르면 현재 런을 버리고 **새로운 시드**로 즉시 새 런을 시작합니다.
캐릭터, 승천 레벨, 게임 모드는 그대로 유지됩니다.

### 설치

1. [Releases](https://github.com/koenma-studio/RerollingNeow/releases)에서 최신 버전을 다운로드합니다.
2. 게임 폴더의 `mods/RerollingNeow/`에 아래 파일을 넣습니다:
   - `RerollingNeow.dll`
   - `RerollingNeow.pck`
   - `RerollingNeow.json`
3. 게임 내 모드 메뉴에서 **Rerolling Neow**를 활성화합니다.

### 사용법

| 키 | 동작 |
|----|------|
| **F4** | 현재 런 포기 → 새 시드로 새 런 시작 |

- 런이 진행 중일 때만 작동합니다.
- 게임 오버 상태에서는 작동하지 않습니다.
- 화면 전환 중에는 작동하지 않습니다.

### 빌드

```bash
dotnet build -c Release
```

> `RerollingNeow.csproj`의 `STS2GameDir` 경로를 본인의 게임 설치 경로에 맞게 수정하세요.

---

## English

### About

Press **F4** at any point during a run to abandon it and instantly start a **new run with a fresh seed**.
Your character, ascension level, and game mode are preserved.

### Installation

1. Download the latest version from [Releases](https://github.com/koenma-studio/RerollingNeow/releases).
2. Place the following files in `mods/RerollingNeow/` inside your game folder:
   - `RerollingNeow.dll`
   - `RerollingNeow.pck`
   - `RerollingNeow.json`
3. Enable **Rerolling Neow** in the in-game mod menu.

### Usage

| Key | Action |
|-----|--------|
| **F4** | Abandon current run → Start new run with a fresh seed |

- Only works while a run is in progress.
- Does not work on the game-over screen.
- Does not work during screen transitions.

### Building

```bash
dotnet build -c Release
```

> Update `STS2GameDir` in `RerollingNeow.csproj` to match your game installation path.

---

## 简体中文

### 简介

在任何时候按下 **F4** 键即可放弃当前运行，并以**全新种子**立即开始新的运行。
角色、超越等级和游戏模式保持不变。

### 安装

1. 从 [Releases](https://github.com/koenma-studio/RerollingNeow/releases) 下载最新版本。
2. 将以下文件放入游戏目录的 `mods/RerollingNeow/` 文件夹中：
   - `RerollingNeow.dll`
   - `RerollingNeow.pck`
   - `RerollingNeow.json`
3. 在游戏内的模组菜单中启用 **Rerolling Neow**。

### 使用方法

| 按键 | 功能 |
|------|------|
| **F4** | 放弃当前运行 → 以新种子开始新运行 |

- 仅在运行进行中时有效。
- 在游戏结束界面无效。
- 在画面切换过程中无效。

### 构建

```bash
dotnet build -c Release
```

> 请将 `RerollingNeow.csproj` 中的 `STS2GameDir` 路径修改为您的游戏安装路径。

---

## 繁體中文

### 簡介

在任何時候按下 **F4** 鍵即可放棄當前運行，並以**全新種子**立即開始新的運行。
角色、超越等級和遊戲模式保持不變。

### 安裝

1. 從 [Releases](https://github.com/koenma-studio/RerollingNeow/releases) 下載最新版本。
2. 將以下檔案放入遊戲目錄的 `mods/RerollingNeow/` 資料夾中：
   - `RerollingNeow.dll`
   - `RerollingNeow.pck`
   - `RerollingNeow.json`
3. 在遊戲內的模組選單中啟用 **Rerolling Neow**。

### 使用方法

| 按鍵 | 功能 |
|------|------|
| **F4** | 放棄當前運行 → 以新種子開始新運行 |

- 僅在運行進行中時有效。
- 在遊戲結束畫面無效。
- 在畫面切換過程中無效。

### 建置

```bash
dotnet build -c Release
```

> 請將 `RerollingNeow.csproj` 中的 `STS2GameDir` 路徑修改為您的遊戲安裝路徑。

---

## 日本語

### 概要

ラン中にいつでも **F4** キーを押すと、現在のランを破棄し、**新しいシード**で即座に新しいランを開始します。
キャラクター、アセンションレベル、ゲームモードはそのまま維持されます。

### インストール

1. [Releases](https://github.com/koenma-studio/RerollingNeow/releases) から最新版をダウンロードします。
2. ゲームフォルダの `mods/RerollingNeow/` に以下のファイルを配置します：
   - `RerollingNeow.dll`
   - `RerollingNeow.pck`
   - `RerollingNeow.json`
3. ゲーム内のMODメニューで **Rerolling Neow** を有効にします。

### 使い方

| キー | 動作 |
|------|------|
| **F4** | 現在のランを破棄 → 新しいシードで新ランを開始 |

- ランが進行中の場合のみ動作します。
- ゲームオーバー画面では動作しません。
- 画面遷移中は動作しません。

### ビルド

```bash
dotnet build -c Release
```

> `RerollingNeow.csproj` の `STS2GameDir` パスをご自身のゲームインストールパスに変更してください。

---

## License

MIT
