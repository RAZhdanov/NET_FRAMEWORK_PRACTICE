using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ABCInc.DAL;

namespace ABCInc.Views.Converters
{
    public class AgeTopensionerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values is null || values.Length != 2 ||  !(values[0] is int) || !(values[1] is Gender)) return DependencyProperty.UnsetValue;
            int age = (int)values[0];
            Gender gender = (Gender) values[1];
            if ((age >= 65 && gender == Gender.Male) ||
                (age >= 60 && gender == Gender.Female))
                return "pensioner";
            return string.Empty;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
