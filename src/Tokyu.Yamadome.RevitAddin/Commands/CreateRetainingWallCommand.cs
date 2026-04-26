using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Interop;
using Tokyu.Yamadome.RevitAddin.Views;

namespace Tokyu.Yamadome.RevitAddin.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CreateRetainingWallCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var window = new RetainingWallWindow(commandData.Application.ActiveUIDocument?.Document?.Title);
            new WindowInteropHelper(window)
            {
                Owner = commandData.Application.MainWindowHandle
            };

            var dialogResult = window.ShowDialog();
            if (dialogResult != true)
            {
                return Result.Cancelled;
            }

            var settings = window.Settings;
            TaskDialog.Show(
                "山留め壁作成",
                "山留め壁作成は現在UI確認用のダミー実装です。\n\n" +
                $"入力元: {settings.InputSource}\n" +
                $"壁種: {settings.WallKind}\n" +
                $"ファミリタイプ: {settings.FamilyType}\n" +
                $"上端: {settings.TopLevel} {settings.TopOffsetMillimeters}mm\n" +
                $"下端: {settings.BottomLevel} {settings.BottomOffsetMillimeters}mm\n" +
                $"Excel仕様: {settings.SpecSource}\n\n" +
                "次工程で、この設定をRevit APIの作成処理へ接続します。");

            return Result.Succeeded;
        }
    }
}

