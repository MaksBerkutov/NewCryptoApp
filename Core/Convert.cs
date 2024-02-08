using NewCryptoApp.Core.API.CryptoCompare.Model;
using System;
using System.Collections.Generic;
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

    public class ConvertDateTime
    {
        public static DateTime ConvertUnixToDateTime(long Unix)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(Unix).ToLocalTime();
            return dateTime;
        }
    }
    public class ConvertChartHistoryPoint
    {
        public class ChartConvert
        {
            public List<double> Hight = new List<double>();
            public List<double> Low = new List<double>();
            public List<double> Open = new List<double>();
            public List<double> Close = new List<double>();
            public List<DateTime> Time = new List<DateTime>();

        }
        public static ChartConvert ConvertToChartConvert(ChartHistoryPointDTO[] Data)
        {

            ChartConvert converted = new ChartConvert();
            foreach (var item in Data)
            {
                converted.Hight.Add(item.High);
                converted.Low.Add(item.Low);
                converted.Open.Add(item.Open);
                converted.Close.Add(item.Close);
                converted.Time.Add(ConvertDateTime.ConvertUnixToDateTime(item.Time));
            }
            return converted;
        }
    }
}
