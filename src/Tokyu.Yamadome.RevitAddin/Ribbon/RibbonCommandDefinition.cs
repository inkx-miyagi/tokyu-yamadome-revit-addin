using System;

namespace Tokyu.Yamadome.RevitAddin.Ribbon
{
    internal sealed class RibbonCommandDefinition
    {
        public RibbonCommandDefinition(
            string panelName,
            string text,
            Type commandType,
            string iconName,
            bool isLargeButton,
            string sourceDynamo)
        {
            PanelName = panelName;
            Text = text;
            CommandType = commandType;
            IconName = iconName;
            IsLargeButton = isLargeButton;
            SourceDynamo = sourceDynamo;
        }

        public string PanelName { get; }
        public string Text { get; }
        public Type CommandType { get; }
        public string IconName { get; }
        public bool IsLargeButton { get; }
        public string SourceDynamo { get; }
    }
}

