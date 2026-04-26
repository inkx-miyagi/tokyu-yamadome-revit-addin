using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autodesk.Revit.UI;

namespace Tokyu.Yamadome.RevitAddin.Ribbon
{
    internal static class RibbonBuilder
    {
        public static void Build(UIControlledApplication application)
        {
            EnsureTab(application, RibbonConstants.TabName);

            foreach (var group in RibbonCommandCatalog.Commands.GroupBy(command => command.PanelName))
            {
                var panel = application.CreateRibbonPanel(RibbonConstants.TabName, group.Key);
                AddCommands(panel, group.ToList());
            }
        }

        private static void EnsureTab(UIControlledApplication application, string tabName)
        {
            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                // The tab already exists. Revit throws instead of returning the existing tab.
            }
        }

        private static void AddCommands(RibbonPanel panel, IList<RibbonCommandDefinition> commands)
        {
            var smallButtons = new List<PushButtonData>();

            foreach (var command in commands)
            {
                var buttonData = CreateButtonData(command);

                if (command.IsLargeButton)
                {
                    FlushSmallButtons(panel, smallButtons);
                    panel.AddItem(buttonData);
                    continue;
                }

                smallButtons.Add(buttonData);
                if (smallButtons.Count == 3)
                {
                    FlushSmallButtons(panel, smallButtons);
                }
            }

            FlushSmallButtons(panel, smallButtons);
        }

        private static PushButtonData CreateButtonData(RibbonCommandDefinition command)
        {
            var buttonData = new PushButtonData(
                command.CommandType.Name,
                command.Text,
                Assembly.GetExecutingAssembly().Location,
                command.CommandType.FullName)
            {
                ToolTip = $"{command.Text}（ダミー）",
                LongDescription = $"現状はリボン構成確認用のダミーコマンドです。対象Dynamo: {command.SourceDynamo}",
                Image = IconLoader.Load(command.IconName),
                LargeImage = IconLoader.Load(command.IconName)
            };

            return buttonData;
        }

        private static void FlushSmallButtons(RibbonPanel panel, IList<PushButtonData> smallButtons)
        {
            if (smallButtons.Count == 0)
            {
                return;
            }

            if (smallButtons.Count == 1)
            {
                panel.AddItem(smallButtons[0]);
            }
            else if (smallButtons.Count == 2)
            {
                panel.AddStackedItems(smallButtons[0], smallButtons[1]);
            }
            else
            {
                panel.AddStackedItems(smallButtons[0], smallButtons[1], smallButtons[2]);
            }

            smallButtons.Clear();
        }
    }
}

