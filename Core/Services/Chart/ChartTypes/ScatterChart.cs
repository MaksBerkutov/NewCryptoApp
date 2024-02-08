using NewCryptoApp.Core.API.CryptoCompare.Model;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.Services
{
    class ScatterChart : IRenderChart
    {
        
        public async Task<object> Convert(ChartHistoryPointDTO[] Points)
        {
            return await Task.Run(() => ConvertChartHistoryPoint.ConvertToChartConvert(Points));
        }
        private void BuilderLineHelper( Scatter scatter,string Name,Color Colors,LinePattern LinePattens = LinePattern.Solid,int LineWidth = 2)
        {
            scatter.Label = Name;
            scatter.Color = Colors;
            scatter.LinePattern = LinePattens;
            scatter.LineWidth = LineWidth;
        }
        public void Render(ref WpfPlot Chart, object ConvertedData)
        {
            var Converted = ConvertedData as ConvertChartHistoryPoint.ChartConvert;
            BuilderLineHelper(
                Chart.Plot.Add.Scatter(Converted.Time, Converted.Hight),
                "High", Colors.Green, LineWidth: 3);
            BuilderLineHelper(
                 Chart.Plot.Add.Scatter(Converted.Time, Converted.Low),
                 "Low", Colors.Red, LineWidth: 3);
            BuilderLineHelper(
                            Chart.Plot.Add.Scatter(Converted.Time, Converted.Open),
                            "Open", Colors.Black, LinePattens: LinePattern.Dashed);
            BuilderLineHelper(
                           Chart.Plot.Add.Scatter(Converted.Time, Converted.Close),
                           "Close", Colors.Yellow, LinePattens: LinePattern.Dashed);

            Chart.Plot.Axes.DateTimeTicksBottom();
            Chart.Plot.ShowLegend();

        }
    }
}
