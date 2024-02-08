using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.MVVM.View;
using System.Diagnostics;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    class MoreInfoExchangesViewModel:ViewModel
    {
        public Command Back { get; }
        public Command GoToFacebook { get; }
        public Command GoToReddit { get; }
        public Command GoToTelegram { get; }
        public Command GoToTwitter { get; }
        public Command GoToSite { get; }

        private async void LoadData(string id)
        {
            Exchanges = await CoinGeskoAPI.GetMoreInfoExchange(id);
            Store<MoreInfoExchangesDTO>.Register(Exchanges);
        }
        private bool ValidateUrl(string url) => url != null && url != string.Empty;
        public MoreInfoExchangesViewModel()
        {
            Back = new Command(async (_) =>
            {
                Store<MarketDTO>.Clear();
                await Navigate.GoToAsync(nameof(TradePageView));
            });
            GoToFacebook = new Command((_) => Process.Start(Exchanges.FacebookUrl), (_) => ValidateUrl(Exchanges?.FacebookUrl));
            GoToReddit = new Command((_) => Process.Start(Exchanges.RedditUrl), (_) => ValidateUrl(Exchanges?.RedditUrl));
            GoToTelegram = new Command((_) => Process.Start(Exchanges.TelegramUrl), (_) => ValidateUrl(Exchanges?.TelegramUrl));
            GoToTwitter = new Command((_) => Process.Start(Exchanges.TwitterUrl), (_) => ValidateUrl(Exchanges?.TwitterUrl));
            GoToSite = new Command((_) => Process.Start(Exchanges.MainUrl), (_) => ValidateUrl(Exchanges?.MainUrl));


            var market = Store<MarketDTO>.Get();
            var save = Store<MoreInfoExchangesDTO>.GetOrNull();
            if (save?.Name.ToLower() == market.Name.ToLower())
                Exchanges = save;
            else 
                LoadData(market.Id);
            
        }

        private MoreInfoExchangesDTO exchanges;

        public MoreInfoExchangesDTO Exchanges
        {
            get => exchanges;
            set => SetProperty(ref exchanges, value);
        }

    }
}
