using NewCryptoApp.Core.API.CryptoCompare.Model;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.Services
{
    class SignalChart : IRenderChart
    {
        public async Task<object> Convert(ChartHistoryPointDTO[] Points)
        {
            return await Task.Run(() =>
            {
                return ConvertChartHistoryPoint.ConvertToChartConvert(Points);
            });
        }
        private void BuilderLineHelper(SignalXY scatter, string Name, Color Colors, LinePattern LinePattens = LinePattern.Solid, int LineWidth = 2)
        {
            scatter.Label = Name;
            scatter.Color = Colors;
            scatter.LineWidth = LineWidth;
        }
        public void Render(ref WpfPlot Chart, object ConvertedData)
        {
            var Converted = ConvertedData as ConvertChartHistoryPoint.ChartConvert;
            BuilderLineHelper(
                  Chart.Plot.Add.SignalXY(Converted.Time.ToArray(), Converted.Hight.ToArray()),
                "High", Colors.Green, LineWidth: 3);
            BuilderLineHelper(
                   Chart.Plot.Add.SignalXY(Converted.Time.ToArray(), Converted.Low.ToArray()),
                 "Low", Colors.Red, LineWidth: 3);
            BuilderLineHelper(
                            Chart.Plot.Add.SignalXY(Converted.Time.ToArray(), Converted.Open.ToArray()),
                            "Open", Colors.Black, LinePattens: LinePattern.Dashed);
            BuilderLineHelper(
                             Chart.Plot.Add.SignalXY(Converted.Time.ToArray(), Converted.Close.ToArray()),
                           "Close", Colors.Yellow, LinePattens: LinePattern.Dashed);

            Chart.Plot.Axes.DateTimeTicksBottom();
            Chart.Plot.ShowLegend();

        }
    }
}
