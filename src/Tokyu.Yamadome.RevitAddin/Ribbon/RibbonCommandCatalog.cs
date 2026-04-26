using System.Collections.Generic;
using Tokyu.Yamadome.RevitAddin.Commands;

namespace Tokyu.Yamadome.RevitAddin.Ribbon
{
    internal static class RibbonCommandCatalog
    {
        public static IReadOnlyList<RibbonCommandDefinition> Commands { get; } =
            new List<RibbonCommandDefinition>
            {
                Large("初期設定", "初期設定", typeof(InitialSettingsCommand), "initial-settings", "00_初期設定"),

                Large("表示設定", "躯体表示", typeof(StructureVisibilityCommand), "structure-visibility", "01_躯体表示"),
                Large("表示設定", "BG/CDモード", typeof(BgCdModeCommand), "bgcd-mode", "30_BGCDモード"),
                Small("表示設定", "切梁色分け", typeof(StrutColorCommand), "strut-color", "19_切梁色分け"),
                Small("表示設定", "ケース表示切替", typeof(CaseLabelVisibilityCommand), "case-label", "21_山留めケース線分立体文字作表示・非表示"),
                Small("表示設定", "根伐り底レベル表示", typeof(ExcavationBottomLevelCommand), "bottom-level", "22_根伐り底のレベル表示"),

                Large("掘削", "掘削形状作成", typeof(CreateExcavationShapeCommand), "excavation-shape", "02_掘削形状作成"),
                Large("掘削", "掘削モデル修正", typeof(FixExcavationModelCommand), "excavation-fix", "04_掘削モデル自動修正"),
                Small("掘削", "モデル線分生成", typeof(CreateModelLinesCommand), "model-lines", "03_面にモデル線分を生成"),
                Small("掘削", "掘削ライン結合", typeof(JoinExcavationLinesCommand), "line-join", "20_掘削ライン結合"),

                Large("山留め部材", "山留め壁作成", typeof(CreateRetainingWallCommand), "wall", "05_山留め壁作成"),
                Large("山留め部材", "腹起し作成", typeof(CreateWalerCommand), "waler", "06_腹起し作成"),
                Large("山留め部材", "切梁作成", typeof(CreateStrutCommand), "strut", "07_切梁作成"),
                Small("山留め部材", "火打ち作成", typeof(CreateCornerBraceCommand), "corner-brace", "08_隅火打ち作成"),
                Small("山留め部材", "切梁支柱作成", typeof(CreateStrutPostCommand), "post", "10_切梁支柱作成"),
                Small("山留め部材", "地盤アンカー作成", typeof(CreateGroundAnchorCommand), "anchor", "13_地盤アンカー作成"),

                Large("部材調整", "火打ち調整", typeof(AdjustCornerBraceCommand), "adjust-brace", "09_火打ち調整"),
                Small("部材調整", "アンカー角度調整", typeof(AdjustAnchorAngleCommand), "anchor-angle", "14_地盤アンカー角度調整"),
                Small("部材調整", "火打ち本数追加", typeof(AddCornerBraceCountCommand), "brace-count", "23_火打ち本数追加"),
                Small("部材調整", "腹起し勝ち負け調整", typeof(AdjustWalerPriorityCommand), "waler-priority", "25_腹起し勝ち負け調整"),

                Small("構台・BG/CD", "構台2D配置", typeof(PlacePlatform2dCommand), "platform-2d", "11_構台2D配置"),
                Large("構台・BG/CD", "構台作成", typeof(CreatePlatformCommand), "platform", "12_構台作成"),
                Small("構台・BG/CD", "BG/CD 2D配置", typeof(PlaceBgCd2dCommand), "bgcd-2d", "26_BG・CD_2D配置"),
                Large("構台・BG/CD", "BG/CD 3D配置", typeof(PlaceBgCd3dCommand), "bgcd-3d", "27_BG・CD_3D配置"),

                Large("埋戻し", "埋戻しソリッド生成", typeof(CreateBackfillSolidCommand), "backfill", "15_埋戻しソリッドを生成"),
                Small("埋戻し", "レベル方向分割", typeof(SplitBackfillByLevelCommand), "split-level", "16_埋戻しソリッド分割_レベル方向"),
                Small("埋戻し", "水平方向分割", typeof(SplitBackfillHorizontalCommand), "split-horizontal", "17_埋戻しソリッド分割_水平方向"),

                Large("既存躯体", "既存躯体再現", typeof(RecreateExistingStructureCommand), "existing-structure", "28_既存躯体再現"),
                Small("既存躯体", "躯体タイプ作成", typeof(CreateStructureFamilyTypeCommand), "structure-type", "31_躯体ファミリタイプ作成"),

                Large("図面化", "ステップビュー作成", typeof(CreateStepViewsCommand), "step-view", "29_ステップビュー作成"),
                Large("図面化", "山留ビュー作成", typeof(CreateYamadomeViewsCommand), "view", "32_山留_ビュー作成"),
                Small("図面化", "山留凡例作成", typeof(CreateYamadomeLegendCommand), "legend", "33_山留_凡例_作成"),
                Large("図面化", "山留シート作成", typeof(CreateYamadomeSheetsCommand), "sheet", "34_山留_シート作成"),
                Small("図面化", "レイアウト保存", typeof(SaveYamadomeLayoutCommand), "layout-save", "35_山留_レイアウト保存"),
                Small("図面化", "ビューテンプレート転送", typeof(TransferViewTemplateCommand), "template-transfer", "36_ビューテンプレート転送"),

                Large("集計", "山留め集計", typeof(YamadomeScheduleCommand), "schedule", "18_山留め集計"),
            };

        private static RibbonCommandDefinition Large(string panelName, string text, System.Type commandType, string iconName, string sourceDynamo)
        {
            return new RibbonCommandDefinition(panelName, text, commandType, iconName, true, sourceDynamo);
        }

        private static RibbonCommandDefinition Small(string panelName, string text, System.Type commandType, string iconName, string sourceDynamo)
        {
            return new RibbonCommandDefinition(panelName, text, commandType, iconName, false, sourceDynamo);
        }
    }
}

