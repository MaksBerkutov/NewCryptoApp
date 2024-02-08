using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.MVVM.View;
using System.Linq;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    class MainPageViewModel : ViewModel
    {
        public Command Update { get; }
        public Command ToGraphics { get; }
        public Command ToInfo { get; }
         

        public MainPageViewModel()
        {
            UpdateItems();
            Update = new Command(UpdateItems, (_) => limit > 0);
            ToGraphics = new Command(GoToGraphics, (_) => selectedCoin != null);
            ToInfo = new Command(GoToInfo, (_) => selectedCoin != null);
        }
        public async void GoToInfo(object obj = null)
        {
            Store.Register(selectedCoin);
            await Navigate.GoToAsync(nameof(InfoPageView));
        }
        public async void GoToGraphics(object obj = null)
        {
            Store.Register(selectedCoin);
            await Navigate.GoToAsync(nameof(ChartPageView));
        }
        public async void UpdateItems(object obj = null)
        {
            var collection = await CoinGeskoAPI.GetTopCoins(Limit: limit);
            Coins = collection.ToArray();

        }


        private int limit = 10;

        public int Limit
        {
            get => limit;
            set
            {
                if (limit > 0&&limit!=value)
                    SetProperty(ref limit, value, nameof(Limit));
            }
        }

        private CoinsDTO[] coins;

        public CoinsDTO[] Coins
        {
            get => coins;
            set => SetProperty(ref coins, value);
        }

        private CoinsDTO selectedCoin = null;

        public CoinsDTO SelectedCoin
        {
            get => selectedCoin;
            set => SetProperty(ref selectedCoin, value); 
             
        }
        





    }
}
