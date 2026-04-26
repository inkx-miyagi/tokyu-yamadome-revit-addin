# 東急建設 生産技術部 山留め支援 Revitアドイン

## 概要

本リポジトリは、山留め関連Dynamo一式をRevitアドインへ移行するための開発用リポジトリです。

現行ではOrkestraによりDynamoをRevitリボン上のコマンドのように実行していますが、アドイン化ではRevit APIベースの通常コマンドとして再構成し、操作性、安定性、保守性の向上を目指します。

## 前提

- 施主名: 東急建設
- 部署名: 生産技術部
- 暫定リボンタブ名: 生産技術部
- 対象: 山留め関連Dynamo一式
- 対象Revit: Revit 2023想定
- 開発言語: C#
- フレームワーク: .NET Framework 4.8想定
- UI: WPF想定

## 機能分類

- 初期設定
- 表示設定
- 掘削
- 山留め部材
- 部材調整
- 構台・BG/CD
- 埋戻し
- 既存躯体
- 図面化
- 集計

## 資料

- [リボンタブ・パネル・コマンド構成案](docs/ribbon-structure.md)
- [開発メモ](docs/development-notes.md)

## 開発用ビルド

```powershell
& 'C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe' .\Tokyu.Yamadome.RevitAddin.sln /p:Configuration=Debug /p:Platform="Any CPU" /m
```

## Revit 2023への開発用登録

```powershell
.\tools\install-revit-addin.ps1
```

上記を実行すると、ビルド後に `%APPDATA%\Autodesk\Revit\Addins\2023\Tokyu.Yamadome.RevitAddin.addin` を作成します。
Revit 2023を起動すると、暫定タブ「生産技術部」にダミーコマンド群が表示されます。

## アイコン再生成

```powershell
.\tools\generate-placeholder-icons.ps1
```
