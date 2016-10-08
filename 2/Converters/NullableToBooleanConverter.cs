using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _2.Converters
{
    public class NullableToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? nullable = (bool?)value;
            return nullable.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool boolvalue = (bool)value;
            bool? nullable = boolvalue;
            return nullable;
        }
    }
}
