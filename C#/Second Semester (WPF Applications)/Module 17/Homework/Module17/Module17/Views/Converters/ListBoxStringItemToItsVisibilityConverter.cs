using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Module17.Views.Converters
{
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class ListBoxStringItemToItsVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            if ((string)value == "" || (string)value == string.Empty)
            {
                return Visibility.Hidden;
            }

            else return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
