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
    [ValueConversion(typeof(Visibility), typeof(Visibility))]
    public class InvertionOfVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility)) return DependencyProperty.UnsetValue;

            if ((Visibility)value == Visibility.Visible) return Visibility.Hidden;
            else if ((Visibility)value == Visibility.Hidden) return Visibility.Visible;
            else return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
