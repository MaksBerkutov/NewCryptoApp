using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.API.CryptoCompare;
using NewCryptoApp.Core.API.CryptoCompare.Model;
using NewCryptoApp.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class ChartPageViewModel:ViewModel
    {
        private readonly string coinId;

        private ChartHistoryDTO ChartDTO;
        public Command Back { get; }
        public Command Update { get; }
        public Command Default { get; }
        public Command Volume { get; }
        private delegate Task<ChartHistoryDTO> GetPoints(string Id, string Valute,int Limit);
        private GetPoints CurrentGetPoint = CryptoCompareAPI.GetChartPointHour;
        private async void LoadData(object obj = null)
        {
           

            ChartDTO = await CurrentGetPoint(coinId, selectedValutes, CountPoint);

            From = ConvertDateTime.ConvertUnixToDateTime(ChartDTO.TimeFrom);
            To = ConvertDateTime.ConvertUnixToDateTime(ChartDTO.TimeTo);
            SelectedChartType = ChartType.First();
        }
       
        public ChartPageViewModel()
        {
            SelectedValutes = Valutes.First();
            ChartType = ChartService.GetTypesChart;
            Update = new Command(LoadData);
            Default = new Command((_) => ChartService.RenderChart(ChartDTO.ChartPoint, SelectedChartType));
            Volume = new Command((_) => ChartService.RenderChartVolume(ChartDTO.ChartPoint));
            Back = new Command(async (_) => await Navigate.Back());
            coinId = Store.Get<CoinsDTO>().Symbol;
            ChartService.OnLoaded += () => LoadData();
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

        private int countPoint = 750;
        public int CountPoint
        {
            get => countPoint;
            set 
            {
                if (value >= 5 && value <= 2000) 
                    SetProperty(ref countPoint, value);
            }
        }

        private bool isMinute = false;
        public bool IsMinute
        {
            get => isMinute;
            set
            {
                SetProperty(ref isMinute, value);
                if (value)  CurrentGetPoint = CryptoCompareAPI.GetChartPointMinute;
            }
        }

        private bool isDay = true;
        public bool IsDay
        {
            get => isDay;
            set
            {
                SetProperty(ref isDay, value);
                if(value) CurrentGetPoint = CryptoCompareAPI.GetChartPointDay;
            }
        }

        private bool isHour = false;
        public bool IsHour
        {
            get => isHour;
            set 
            {
                SetProperty(ref isHour, value);
                if (value) CurrentGetPoint = CryptoCompareAPI.GetChartPointHour;
            }
        }

        private string[] valutes = new string[] { "USD", "UAH", "RUB", "ETH", "BTC" };
        public string[] Valutes
        {
            get => valutes;
            set => SetProperty(ref valutes, value);
        }

        private string selectedValutes;
        public string SelectedValutes
        {
            get => selectedValutes;
            set => SetProperty(ref selectedValutes, value);
        }
    }
}
