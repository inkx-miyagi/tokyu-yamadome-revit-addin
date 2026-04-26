using Autodesk.Revit.UI;
using Tokyu.Yamadome.RevitAddin.Ribbon;

namespace Tokyu.Yamadome.RevitAddin
{
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonBuilder.Build(application);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}

