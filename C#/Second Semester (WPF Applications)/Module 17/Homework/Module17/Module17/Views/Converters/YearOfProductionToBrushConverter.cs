using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Module17.Views.Converters
{
    [ValueConversion(typeof(int), typeof(Brush))]
    public class YearOfProductionToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is int)) return DependencyProperty.UnsetValue;

            int year_of_production = (int)value;
            if(year_of_production >= DateTime.Today.Year - 1 || year_of_production < DateTime.Today.Year)
            {
                return Brushes.Red;
            }
            return Brushes.Black; //by default
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
