using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.MVVM.View;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class InfoPageViewModel : ViewModel
    {
        public Command GoToTradePage { get; }
        public Command Back { get; }
        private async void LoadData(string id)
        {
            MoreInfo = await CoinGeskoAPI.GetMoreInfoCoin(id);
            Store.Register(MoreInfo);

        }
        public InfoPageViewModel()
        {
          
            var coin = Store.GetOrNull<CoinsDTO>();
            var findCoin = Store.GetOrNull<FindCoinsDTO>();
            Image = coin == null ? findCoin.Image : coin.Image;
            GoToTradePage = new Command(GoToTrade);
            Back = new Command(async (_) =>
            {
                await Navigate.Back();
            });
            var saved = Store.GetOrNull<MoreInfoCoinsDTO>();
            if (saved?.Id.ToLower() == coin?.Id.ToLower() && saved?.Id.ToLower() == findCoin?.Id.ToLower())  //Снижаем нагрузку на API при переходе от трейда сюда (меньше запросв дольше можно прожить на пробной версии)
                MoreInfo = saved;
            else
                LoadData(coin == null ? findCoin.Id : coin.Id); 



        }
        public async void GoToTrade(object obj)
        {
            Store.Register(moreInfo.Tickers);
            await Navigate.GoToAsync(nameof(TradePageView));
        }
        public string Image { get; }
       
        private MoreInfoCoinsDTO moreInfo;

        public MoreInfoCoinsDTO MoreInfo
        {
            get => moreInfo;
            set => SetProperty(ref moreInfo, value);
        }

    }
}
