using NewCryptoApp.Core.API.CryptoCompare.Model;
using ScottPlot;
using ScottPlot.WPF;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.Services
{
    class OHLCChart : IRenderChart
    {
        private OHLC ConvertToOHCLFromApi(ChartHistoryPointDTO point)
        {
            var date = ConvertDateTime.ConvertUnixToDateTime(point.Time);
            return new OHLC(point.Open, point.High, point.Low, point.Close, date, date.TimeOfDay);
        }
        public async Task<object> Convert(ChartHistoryPointDTO[] points)
        {
            return await Task.Run(() =>
            {
                return points.Select(x => ConvertToOHCLFromApi(x)).ToList();
            });
        }

        public void Render(ref WpfPlot Chart, object ConvertedData)
        {
            List<OHLC> oHLCs = ConvertedData as List<OHLC>;
           Chart.Plot.Add.OHLC(oHLCs);
            Chart.Plot.Axes.DateTimeTicksBottom();

        }
    }
}
