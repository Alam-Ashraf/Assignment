using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinAssignment.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public IntToBoolConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val = (int)value;

            if (val > 0)
            {
                return (Color)Application.Current.Resources["ColorGray"];
            }
            else
            {
                return (Color)Application.Current.Resources["ColorRed"];
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }
    }
}
