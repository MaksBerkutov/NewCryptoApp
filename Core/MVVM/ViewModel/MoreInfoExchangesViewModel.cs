using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
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
            Store.Register(Exchanges);
        }
        private bool ValidateUrl(string url) => url != null && url != string.Empty;
        public MoreInfoExchangesViewModel()
        {
            Back = new Command(async (_) =>
            {
                Store.Clear<MarketDTO>();

                await Navigate.Back();
            });
            GoToFacebook = new Command((_) => Process.Start(Exchanges.FacebookUrl), (_) => ValidateUrl(Exchanges?.FacebookUrl));
            GoToReddit = new Command((_) => Process.Start(Exchanges.RedditUrl), (_) => ValidateUrl(Exchanges?.RedditUrl));
            GoToTelegram = new Command((_) => Process.Start(Exchanges.TelegramUrl), (_) => ValidateUrl(Exchanges?.TelegramUrl));
            GoToTwitter = new Command((_) => Process.Start(Exchanges.TwitterUrl), (_) => ValidateUrl(Exchanges?.TwitterUrl));
            GoToSite = new Command((_) => Process.Start(Exchanges.MainUrl), (_) => ValidateUrl(Exchanges?.MainUrl));


            var market = Store.GetOrNull<MarketDTO>();
            var findMarket = Store.GetOrNull<FindExchangesDTO>();
            var save = Store.GetOrNull<MoreInfoExchangesDTO>();
            if (save?.Name.ToLower() == market?.Name.ToLower() && save?.Name.ToLower() == findMarket?.Name.ToLower())
                Exchanges = save;
            else
                LoadData(market == null ? findMarket.Id : market.Id);

        }

        private MoreInfoExchangesDTO exchanges;

        public MoreInfoExchangesDTO Exchanges
        {
            get => exchanges;
            set => SetProperty(ref exchanges, value);
        }

    }
}
