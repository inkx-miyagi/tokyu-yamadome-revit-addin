using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tokyu.Yamadome.RevitAddin.Views
{
    public sealed class RetainingWallWindow : Window
    {
        private readonly ComboBox _inputSourceComboBox;
        private readonly ComboBox _wallKindComboBox;
        private readonly ComboBox _familyTypeComboBox;
        private readonly ComboBox _topLevelComboBox;
        private readonly TextBox _topOffsetTextBox;
        private readonly ComboBox _bottomLevelComboBox;
        private readonly TextBox _bottomOffsetTextBox;
        private readonly TextBox _specSourceTextBox;
        private readonly CheckBox _updateExistingWallsCheckBox;
        private readonly CheckBox _warnMissingFamiliesCheckBox;
        private readonly CheckBox _applyViewAfterCreateCheckBox;

        public RetainingWallWindow(string documentTitle)
        {
            Title = "山留め壁作成";
            Width = 720;
            MinWidth = 680;
            Height = 640;
            MinHeight = 600;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ResizeMode = ResizeMode.CanResize;
            Background = Brushes.White;

            _inputSourceComboBox = CreateComboBox("選択中のモデル線分", "掘削ライン", "閉じた線分ループ", "Excel仕様から作成");
            _wallKindComboBox = CreateComboBox("SMW", "親杭横矢板", "鋼矢板", "地中連続壁", "任意壁タイプ");
            _familyTypeComboBox = CreateComboBox("仮: 山留め壁_SMW", "仮: 山留め壁_親杭", "仮: 山留め壁_鋼矢板");
            _topLevelComboBox = CreateComboBox("GL", "1FL", "設計GL", "現在ビューのレベル");
            _topOffsetTextBox = CreateTextBox("0");
            _bottomLevelComboBox = CreateComboBox("根伐り底", "B1FL", "B2FL", "指定レベル");
            _bottomOffsetTextBox = CreateTextBox("0");
            _specSourceTextBox = CreateTextBox("初期設定のExcel仕様を使用");
            _updateExistingWallsCheckBox = CreateCheckBox("同名/同一線上の既存山留め壁を更新対象にする", false);
            _warnMissingFamiliesCheckBox = CreateCheckBox("必要ファミリが見つからない場合は実行前に警告する", true);
            _applyViewAfterCreateCheckBox = CreateCheckBox("作成後に表示設定を適用する", true);

            Content = BuildContent(documentTitle);
        }

        public RetainingWallSettings Settings { get; private set; }

        private UIElement BuildContent(string documentTitle)
        {
            var root = new DockPanel();

            var header = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(36, 82, 130)),
                Padding = new Thickness(20, 16, 20, 14),
                Child = new StackPanel
                {
                    Children =
                    {
                        new TextBlock
                        {
                            Text = "山留め壁作成",
                            Foreground = Brushes.White,
                            FontSize = 20,
                            FontWeight = FontWeights.SemiBold
                        },
                        new TextBlock
                        {
                            Text = string.IsNullOrWhiteSpace(documentTitle)
                                ? "リボン構成確認用の暫定UI"
                                : $"対象モデル: {documentTitle}",
                            Foreground = new SolidColorBrush(Color.FromRgb(221, 235, 247)),
                            Margin = new Thickness(0, 4, 0, 0)
                        }
                    }
                }
            };
            DockPanel.SetDock(header, Dock.Top);
            root.Children.Add(header);

            var buttons = BuildButtons();
            DockPanel.SetDock(buttons, Dock.Bottom);
            root.Children.Add(buttons);

            var scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = BuildForm()
            };
            root.Children.Add(scrollViewer);

            return root;
        }

        private UIElement BuildForm()
        {
            var panel = new StackPanel
            {
                Margin = new Thickness(20)
            };

            panel.Children.Add(CreateSectionTitle("入力条件"));
            panel.Children.Add(CreateField("入力元", _inputSourceComboBox));
            panel.Children.Add(CreateField("壁種", _wallKindComboBox));
            panel.Children.Add(CreateField("ファミリタイプ", _familyTypeComboBox));

            panel.Children.Add(CreateSectionTitle("高さ条件"));
            panel.Children.Add(CreateTwoColumnFields("上端レベル", _topLevelComboBox, "上端オフセット(mm)", _topOffsetTextBox));
            panel.Children.Add(CreateTwoColumnFields("下端レベル", _bottomLevelComboBox, "下端オフセット(mm)", _bottomOffsetTextBox));

            panel.Children.Add(CreateSectionTitle("仕様・オプション"));
            panel.Children.Add(CreateField("仕様入力", _specSourceTextBox));
            panel.Children.Add(_updateExistingWallsCheckBox);
            panel.Children.Add(_warnMissingFamiliesCheckBox);
            panel.Children.Add(_applyViewAfterCreateCheckBox);

            panel.Children.Add(CreateSectionTitle("事前チェック"));
            panel.Children.Add(CreateCheckSummary());

            return panel;
        }

        private UIElement BuildButtons()
        {
            var border = new Border
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(226, 232, 240)),
                BorderThickness = new Thickness(0, 1, 0, 0),
                Padding = new Thickness(20, 12, 20, 12),
                Background = new SolidColorBrush(Color.FromRgb(248, 250, 252))
            };

            var buttons = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var cancelButton = CreateButton("キャンセル", false);
            cancelButton.Click += (sender, args) =>
            {
                DialogResult = false;
                Close();
            };

            var executeButton = CreateButton("実行（ダミー）", true);
            executeButton.Click += (sender, args) =>
            {
                if (!TryCollectSettings(out var settings))
                {
                    return;
                }

                Settings = settings;
                DialogResult = true;
                Close();
            };

            buttons.Children.Add(cancelButton);
            buttons.Children.Add(executeButton);
            border.Child = buttons;
            return border;
        }

        private bool TryCollectSettings(out RetainingWallSettings settings)
        {
            settings = null;

            if (!int.TryParse(_topOffsetTextBox.Text, out var topOffset))
            {
                MessageBox.Show(this, "上端オフセットは整数のmm値で入力してください。", "入力確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(_bottomOffsetTextBox.Text, out var bottomOffset))
            {
                MessageBox.Show(this, "下端オフセットは整数のmm値で入力してください。", "入力確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            settings = new RetainingWallSettings
            {
                InputSource = GetSelectedText(_inputSourceComboBox),
                WallKind = GetSelectedText(_wallKindComboBox),
                FamilyType = GetSelectedText(_familyTypeComboBox),
                TopLevel = GetSelectedText(_topLevelComboBox),
                TopOffsetMillimeters = topOffset,
                BottomLevel = GetSelectedText(_bottomLevelComboBox),
                BottomOffsetMillimeters = bottomOffset,
                SpecSource = _specSourceTextBox.Text,
                UpdateExistingWalls = _updateExistingWallsCheckBox.IsChecked == true,
                WarnMissingFamilies = _warnMissingFamiliesCheckBox.IsChecked == true,
                ApplyViewAfterCreate = _applyViewAfterCreateCheckBox.IsChecked == true
            };

            return true;
        }

        private static TextBlock CreateSectionTitle(string text)
        {
            return new TextBlock
            {
                Text = text,
                FontSize = 14,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(30, 41, 59)),
                Margin = new Thickness(0, 18, 0, 8)
            };
        }

        private static UIElement CreateField(string label, Control input)
        {
            var grid = CreateFieldGrid();
            grid.Children.Add(CreateLabel(label));
            Grid.SetColumn(input, 1);
            grid.Children.Add(input);
            return grid;
        }

        private static UIElement CreateTwoColumnFields(string leftLabel, Control leftInput, string rightLabel, Control rightInput)
        {
            var grid = new Grid
            {
                Margin = new Thickness(0, 0, 0, 8)
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(132) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(130) });

            grid.Children.Add(CreateLabel(leftLabel));
            Grid.SetColumn(leftInput, 1);
            grid.Children.Add(leftInput);

            var rightText = CreateLabel(rightLabel);
            rightText.Margin = new Thickness(18, 0, 8, 0);
            Grid.SetColumn(rightText, 2);
            grid.Children.Add(rightText);

            Grid.SetColumn(rightInput, 3);
            grid.Children.Add(rightInput);
            return grid;
        }

        private static Grid CreateFieldGrid()
        {
            var grid = new Grid
            {
                Margin = new Thickness(0, 0, 0, 8)
            };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            return grid;
        }

        private static TextBlock CreateLabel(string text)
        {
            return new TextBlock
            {
                Text = text,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Color.FromRgb(71, 85, 105)),
                Margin = new Thickness(0, 0, 8, 0)
            };
        }

        private static ComboBox CreateComboBox(params string[] items)
        {
            var comboBox = new ComboBox
            {
                MinHeight = 28,
                IsEditable = false
            };

            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }

            comboBox.SelectedIndex = 0;
            return comboBox;
        }

        private static TextBox CreateTextBox(string text)
        {
            return new TextBox
            {
                Text = text,
                MinHeight = 28,
                VerticalContentAlignment = VerticalAlignment.Center,
                Padding = new Thickness(6, 0, 6, 0)
            };
        }

        private static CheckBox CreateCheckBox(string text, bool isChecked)
        {
            return new CheckBox
            {
                Content = text,
                IsChecked = isChecked,
                Margin = new Thickness(100, 4, 0, 4),
                Foreground = new SolidColorBrush(Color.FromRgb(51, 65, 85))
            };
        }

        private static Button CreateButton(string text, bool isPrimary)
        {
            return new Button
            {
                Content = text,
                MinWidth = isPrimary ? 120 : 96,
                MinHeight = 32,
                Margin = new Thickness(8, 0, 0, 0),
                Padding = new Thickness(14, 4, 14, 4),
                FontWeight = isPrimary ? FontWeights.SemiBold : FontWeights.Normal
            };
        }

        private static UIElement CreateCheckSummary()
        {
            return new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(248, 250, 252)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(203, 213, 225)),
                BorderThickness = new Thickness(1),
                Padding = new Thickness(12),
                Child = new TextBlock
                {
                    Text = "未実装: 選択線分、ファミリ、レベル、Excel仕様の有無をここに表示予定",
                    Foreground = new SolidColorBrush(Color.FromRgb(71, 85, 105)),
                    TextWrapping = TextWrapping.Wrap
                }
            };
        }

        private static string GetSelectedText(ComboBox comboBox)
        {
            return Convert.ToString(comboBox.SelectedItem);
        }
    }
}

