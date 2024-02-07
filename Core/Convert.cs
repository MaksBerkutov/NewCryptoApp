using System;
using System.Globalization;
using System.Windows.Data;

namespace NewCryptoApp.Core
{
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double actualWidth && parameter is string param)
            {
                if (double.TryParse(param, out double parsedParam))
                {
                    return actualWidth * parsedParam;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
