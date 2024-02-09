using NewCryptoApp.Core.API.CoinCap;
using NewCryptoApp.Core.API.CoinCap.Model;
using NewCryptoApp.Core.Services;
using System.Linq;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class ConvertorPageViewModel:ViewModel
    {
        public Command Convert { get; }
        private async void LoadData()
        {
            Valutes = (await CoinCapAPI.GetValute()).ToArray();
            SelectedValuteTo = SelectedValuteFrom = Valutes.First();
            Coins = (await CoinCapAPI.GetCoins()).ToArray();
            SelectedCoinFrom = SelectedCoinTo = Coins.First();
        }
        public ConvertorPageViewModel()
        {
            Convert = new Command(Converted);
            LoadData();
        }
        private void Converted(object obj)
        {
            ResultCoinToVal = ConvertedValuteService.ConvertCoinToValute(SelectedCoinFrom,SelectedValuteTo,CountCoinToVal);
            ResultValToCoin = ConvertedValuteService.ConvertValuteToCoin(SelectedValuteFrom,SelectedCoinTo,CountValToCoin);
        }

        private CoinDTO[] coins;
        public CoinDTO[] Coins
        {
            get => coins;
            set => SetProperty(ref coins, value);
        }
        private CoinDTO selectedCoinFrom;
        public CoinDTO SelectedCoinFrom
        {
            get => selectedCoinFrom;
            set => SetProperty(ref selectedCoinFrom, value);
        }
        private CoinDTO selectedCoinTo;
        public CoinDTO SelectedCoinTo
        {
            get => selectedCoinTo;
            set => SetProperty(ref selectedCoinTo, value);
        }

        private ValuteDTO[] valutes;
        public ValuteDTO[] Valutes
        {
            get => valutes;
            set => SetProperty(ref valutes, value);
        }
        private ValuteDTO selectedValuteFrom;
        public ValuteDTO SelectedValuteFrom
        {
            get => selectedValuteFrom;
            set => SetProperty(ref selectedValuteFrom, value);
        }
        private ValuteDTO selectedValuteTo;
        public ValuteDTO SelectedValuteTo
        {
            get => selectedValuteTo;
            set => SetProperty(ref selectedValuteTo, value);
        }

        private double countCoinToVal;
        public double CountCoinToVal
        {
            get => countCoinToVal;
            set => SetProperty(ref countCoinToVal, value);
        }

        private double countValToCoin;
        public double CountValToCoin
        {
            get => countValToCoin;
            set => SetProperty(ref countValToCoin, value);
        }

        private string resultCoinToVal;
        public string ResultCoinToVal
        {
            get => resultCoinToVal;
            set => SetProperty(ref resultCoinToVal, value);
        }

        private string resultValToCoin;
        public string ResultValToCoin
        {
            get => resultValToCoin;
            set => SetProperty(ref resultValToCoin, value);
        }

    }
}
