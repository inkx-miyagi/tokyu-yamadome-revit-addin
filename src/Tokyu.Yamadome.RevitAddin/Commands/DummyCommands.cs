namespace Tokyu.Yamadome.RevitAddin.Commands
{
    public class InitialSettingsCommand : DummyCommandBase { protected override string CommandName => "初期設定"; protected override string SourceDynamo => "00_初期設定"; }
    public class StructureVisibilityCommand : DummyCommandBase { protected override string CommandName => "躯体表示"; protected override string SourceDynamo => "01_躯体表示"; }
    public class BgCdModeCommand : DummyCommandBase { protected override string CommandName => "BG/CDモード"; protected override string SourceDynamo => "30_BGCDモード"; }
    public class StrutColorCommand : DummyCommandBase { protected override string CommandName => "切梁色分け"; protected override string SourceDynamo => "19_切梁色分け"; }
    public class CaseLabelVisibilityCommand : DummyCommandBase { protected override string CommandName => "ケース表示切替"; protected override string SourceDynamo => "21_山留めケース線分立体文字作表示・非表示"; }
    public class ExcavationBottomLevelCommand : DummyCommandBase { protected override string CommandName => "根伐り底レベル表示"; protected override string SourceDynamo => "22_根伐り底のレベル表示"; }
    public class CreateExcavationShapeCommand : DummyCommandBase { protected override string CommandName => "掘削形状作成"; protected override string SourceDynamo => "02_掘削形状作成"; }
    public class FixExcavationModelCommand : DummyCommandBase { protected override string CommandName => "掘削モデル修正"; protected override string SourceDynamo => "04_掘削モデル自動修正"; }
    public class CreateModelLinesCommand : DummyCommandBase { protected override string CommandName => "モデル線分生成"; protected override string SourceDynamo => "03_面にモデル線分を生成"; }
    public class JoinExcavationLinesCommand : DummyCommandBase { protected override string CommandName => "掘削ライン結合"; protected override string SourceDynamo => "20_掘削ライン結合"; }
    public class CreateWalerCommand : DummyCommandBase { protected override string CommandName => "腹起し作成"; protected override string SourceDynamo => "06_腹起し作成"; }
    public class CreateStrutCommand : DummyCommandBase { protected override string CommandName => "切梁作成"; protected override string SourceDynamo => "07_切梁作成"; }
    public class CreateCornerBraceCommand : DummyCommandBase { protected override string CommandName => "火打ち作成"; protected override string SourceDynamo => "08_隅火打ち作成"; }
    public class CreateStrutPostCommand : DummyCommandBase { protected override string CommandName => "切梁支柱作成"; protected override string SourceDynamo => "10_切梁支柱作成"; }
    public class CreateGroundAnchorCommand : DummyCommandBase { protected override string CommandName => "地盤アンカー作成"; protected override string SourceDynamo => "13_地盤アンカー作成"; }
    public class AdjustCornerBraceCommand : DummyCommandBase { protected override string CommandName => "火打ち調整"; protected override string SourceDynamo => "09_火打ち調整"; }
    public class AdjustAnchorAngleCommand : DummyCommandBase { protected override string CommandName => "アンカー角度調整"; protected override string SourceDynamo => "14_地盤アンカー角度調整"; }
    public class AddCornerBraceCountCommand : DummyCommandBase { protected override string CommandName => "火打ち本数追加"; protected override string SourceDynamo => "23_火打ち本数追加"; }
    public class AdjustWalerPriorityCommand : DummyCommandBase { protected override string CommandName => "腹起し勝ち負け調整"; protected override string SourceDynamo => "25_腹起し勝ち負け調整"; }
    public class PlacePlatform2dCommand : DummyCommandBase { protected override string CommandName => "構台2D配置"; protected override string SourceDynamo => "11_構台2D配置"; }
    public class CreatePlatformCommand : DummyCommandBase { protected override string CommandName => "構台作成"; protected override string SourceDynamo => "12_構台作成"; }
    public class PlaceBgCd2dCommand : DummyCommandBase { protected override string CommandName => "BG/CD 2D配置"; protected override string SourceDynamo => "26_BG・CD_2D配置"; }
    public class PlaceBgCd3dCommand : DummyCommandBase { protected override string CommandName => "BG/CD 3D配置"; protected override string SourceDynamo => "27_BG・CD_3D配置"; }
    public class CreateBackfillSolidCommand : DummyCommandBase { protected override string CommandName => "埋戻しソリッド生成"; protected override string SourceDynamo => "15_埋戻しソリッドを生成"; }
    public class SplitBackfillByLevelCommand : DummyCommandBase { protected override string CommandName => "レベル方向分割"; protected override string SourceDynamo => "16_埋戻しソリッド分割_レベル方向"; }
    public class SplitBackfillHorizontalCommand : DummyCommandBase { protected override string CommandName => "水平方向分割"; protected override string SourceDynamo => "17_埋戻しソリッド分割_水平方向"; }
    public class RecreateExistingStructureCommand : DummyCommandBase { protected override string CommandName => "既存躯体再現"; protected override string SourceDynamo => "28_既存躯体再現"; }
    public class CreateStructureFamilyTypeCommand : DummyCommandBase { protected override string CommandName => "躯体タイプ作成"; protected override string SourceDynamo => "31_躯体ファミリタイプ作成"; }
    public class CreateStepViewsCommand : DummyCommandBase { protected override string CommandName => "ステップビュー作成"; protected override string SourceDynamo => "29_ステップビュー作成"; }
    public class CreateYamadomeViewsCommand : DummyCommandBase { protected override string CommandName => "山留ビュー作成"; protected override string SourceDynamo => "32_山留_ビュー作成"; }
    public class CreateYamadomeLegendCommand : DummyCommandBase { protected override string CommandName => "山留凡例作成"; protected override string SourceDynamo => "33_山留_凡例_作成"; }
    public class CreateYamadomeSheetsCommand : DummyCommandBase { protected override string CommandName => "山留シート作成"; protected override string SourceDynamo => "34_山留_シート作成"; }
    public class SaveYamadomeLayoutCommand : DummyCommandBase { protected override string CommandName => "レイアウト保存"; protected override string SourceDynamo => "35_山留_レイアウト保存"; }
    public class TransferViewTemplateCommand : DummyCommandBase { protected override string CommandName => "ビューテンプレート転送"; protected override string SourceDynamo => "36_ビューテンプレート転送"; }
    public class YamadomeScheduleCommand : DummyCommandBase { protected override string CommandName => "山留め集計"; protected override string SourceDynamo => "18_山留め集計"; }
}
