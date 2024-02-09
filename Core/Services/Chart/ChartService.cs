using NewCryptoApp.Core.API.CryptoCompare.Model;
using ScottPlot;
using ScottPlot.WPF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NewCryptoApp.Core.Services
{

    public interface IRenderChart
    {
        Task<object> Convert(ChartHistoryPointDTO[] Points);
        void Render(ref WpfPlot Chart,object ConvertedData);
    }
    public static class ChartService
    {
        private static WpfPlot Chart;
        private static readonly Dictionary<string, IRenderChart> RendersChartType = new Dictionary<string, IRenderChart>() {
            {"Candlestick",new CandlestickChart() },
            {"OHLC",new OHLCChart() },
            {"Scatter",new ScatterChart() },
            {"Signal",new SignalChart() },
        };
        public static string[] GetTypesChart => RendersChartType.Keys.ToArray();

        public delegate void Loaded();
        public static event Loaded OnLoaded;

        public static void RegisterChart(ref WpfPlot chart)
        {
            Chart = chart;
            OnLoaded?.Invoke();
        }
        public static async void RenderChart(ChartHistoryPointDTO[] Points, string Render)
        {
           if(RendersChartType.TryGetValue(Render,out var renderValue))
            {
                await RenderChart(Points, renderValue);
            }
        }
        public static async void RenderChartVolume(ChartHistoryPointDTO[] Points)
        {
            if (Points == null) throw new NullReferenceException(nameof(Points));
            await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
            {
                Chart.Plot.Clear();
                Chart.Plot.Add.Bars(Points.Select(x => (double)x.VolumeFrom).ToArray()).Color = Colors.LightGray;
                Chart.Plot.Axes.AutoScale();
                Chart.Refresh();
            });
        }
        public static async Task RenderChart(ChartHistoryPointDTO[] Points, IRenderChart Render)
        {
            if (Points == null) throw new NullReferenceException(nameof(Points));
            await Task.Run(async () =>
            {

                object Data = await Render.Convert(Points);

                await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Chart.Plot.Clear();
                    Render.Render(ref Chart, Data);
                    Chart.Plot.Axes.AutoScale();
                    Chart.Refresh();
                });

            });
        }
    }
}
