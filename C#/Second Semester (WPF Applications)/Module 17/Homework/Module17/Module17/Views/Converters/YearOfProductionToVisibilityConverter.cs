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
    [ValueConversion(typeof(int), typeof(Visibility))]
    public class YearOfProductionToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return DependencyProperty.UnsetValue;

            if ((int)value >= DateTime.Today.Year - 1 && (int)value <= DateTime.Today.Year)
            {
                return Visibility.Visible;
            }
            else return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
