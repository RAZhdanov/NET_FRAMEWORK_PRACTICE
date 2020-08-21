using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ABCInc.Views.Converters
{
    [ValueConversion(typeof(int), typeof(Brush))]
    public class AgeToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return DependencyProperty.UnsetValue;
            int year = (int)value;
            if (year < 0) return DependencyProperty.UnsetValue;

            if (year < 4) return Brushes.Aqua;
            if (year < 12) return Brushes.Bisque;
            if (year < 17) return Brushes.Pink;
            if (year < 25) return Brushes.Orange;
            if (year < 55) return Brushes.Green;
            if (year < 100) return Brushes.Brown;
            return Brushes.Violet;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
