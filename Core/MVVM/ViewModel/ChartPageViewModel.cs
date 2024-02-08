using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.API.CryptoCompare;
using NewCryptoApp.Core.API.CryptoCompare.Model;
using NewCryptoApp.Core.Services;
using System;
using System.Linq;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class ChartPageViewModel:ViewModel
    {
        private ChartHistoryDTO ChartDTO;
        public Command Back { get; }
        private async void LoadData(string Id)
        {
            ChartDTO = await CryptoCompareAPI.GetChartPoint(Id);

            From = ConvertDateTime.ConvertUnixToDateTime(ChartDTO.TimeFrom);
            To = ConvertDateTime.ConvertUnixToDateTime(ChartDTO.TimeTo);
            SelectedChartType = ChartType.First();
        }
        public ChartPageViewModel()
        {
            ChartType = ChartService.GetTypesChart;
            Back = new Command(async (_) =>
            {
                await Navigate.Back();
            });
            var coin = Store.Get<CoinsDTO>();
            ChartService.OnLoaded += () => LoadData(coin.Symbol);
        }

        private string[] chartType;
        public string[] ChartType
        {
            get => chartType;
            set => SetProperty(ref chartType, value);
        }

        private string selectedChartType;
        public string SelectedChartType
        {
            get => selectedChartType;
            set 
            {
                SetProperty(ref selectedChartType, value);
                if (ChartDTO != null)
                    ChartService.RenderChart(ChartDTO.ChartPoint, SelectedChartType);

            }
        }

        private DateTime from;
        public DateTime From
        {
            get => from;
            set => SetProperty(ref from, value);
        }

        private DateTime to;
        public DateTime To
        {
            get => to;
            set => SetProperty(ref to, value);
        }

    }
}
