using ShortcutToMacro.Keyboard;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace ShortcutToMacro.Converters
{
    public class IsKeydownToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is KeyState state)
            {
                if (state == KeyState.Down)
                {
                    return "/ShortcutToMacro;component/Resources/dwnIcon.png";
                }
                else if (state == KeyState.Up)
                {
                    return "/ShortcutToMacro;component/Resources/upIcon.png";
                }
                else
                {
                    return "/ShortcutToMacro;component/Resources/delay.png";
                }
            }
            else
            {
                return "/ShortcutToMacro;component/Resources/delay.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string path && path == "/ShortcutToMacro;component/Resources/dwnIcon.png";
        }
    }
}
