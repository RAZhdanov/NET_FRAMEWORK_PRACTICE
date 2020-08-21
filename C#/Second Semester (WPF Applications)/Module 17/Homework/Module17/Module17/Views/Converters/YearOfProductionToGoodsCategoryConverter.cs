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
    [ValueConversion(typeof(int), typeof(string))]
    public class YearOfProductionToGoodsCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is int)) return DependencyProperty.UnsetValue;

            int year_of_production = (int)value;

            if(year_of_production >= DateTime.Today.Year - 1)
            {
                return "Новинка!";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
