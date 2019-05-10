using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XF4011.Converters
{
    class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                var fooStr = value as string;
                if (fooStr == "1")
                {
                    return Color.Red;
                }
                else if (fooStr == "2")
                {
                    return Color.Green;
                }
                else if (fooStr == "3")
                {
                    return Color.Blue;
                }
                else if (fooStr.ToLower() == "vulcan")
                {
                    return Color.Pink;
                }
                else
                {
                    return Color.Black;
                }
            }
            else
            {
                return Color.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
