using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tokyu.Yamadome.RevitAddin.Ribbon
{
    internal static class IconLoader
    {
        public static ImageSource Load(string iconName)
        {
            var uri = new Uri(
                $"pack://application:,,,/Tokyu.Yamadome.RevitAddin;component/Resources/Icons/{iconName}.png",
                UriKind.Absolute);

            return new BitmapImage(uri);
        }
    }
}

