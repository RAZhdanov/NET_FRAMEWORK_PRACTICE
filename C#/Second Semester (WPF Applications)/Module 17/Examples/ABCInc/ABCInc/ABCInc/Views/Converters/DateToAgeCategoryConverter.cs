using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ABCInc.Views.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class DateToAgeCategoryConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return DependencyProperty.UnsetValue;

            int year = (int)value;
            if (year < 0) return DependencyProperty.UnsetValue;

            if (year < 4) return "infant";
            if (year < 12) return "child";
            if (year < 17) return "teenager";
            if (year < 25) return "adolescent";
            if (year < 55) return "good man";
            if (year < 100) return "old person";
            return "deadman";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
