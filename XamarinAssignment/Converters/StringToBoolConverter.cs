using System;
using System.Globalization;
using Xamarin.Forms;
using XamarinAssignment.Helpers;

namespace XamarinAssignment.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public StringToBoolConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;

            if (!string.IsNullOrEmpty(val))
            {
                if (Utils.IsValidEmail(val))
                {
                    return (Color)Application.Current.Resources["ColorGray"];
                }
                else
                {
                    return (Color)Application.Current.Resources["ColorRed"];
                }
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
