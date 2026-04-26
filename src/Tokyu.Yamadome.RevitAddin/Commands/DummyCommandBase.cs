using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Tokyu.Yamadome.RevitAddin.Commands
{
    [Transaction(TransactionMode.Manual)]
    public abstract class DummyCommandBase : IExternalCommand
    {
        protected abstract string CommandName { get; }
        protected abstract string SourceDynamo { get; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show(
                "山留め支援",
                $"{CommandName}\n\nこのボタンはリボン構成確認用のダミーコマンドです。\n実際の処理はまだ実装していません。\n\n対象Dynamo: {SourceDynamo}");

            return Result.Succeeded;
        }
    }
}

