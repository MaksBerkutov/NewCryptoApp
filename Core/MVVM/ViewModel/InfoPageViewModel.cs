using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class InfoPageViewModel : ViewModel
    {
        public Command GoToTradePage { get; }
        public Command Back { get; }
        private async void LoadData(string id)
        {
            MoreInfo = await CoinGeskoAPI.GetMoreInfoCoin(id);
            Store<MoreInfoCoins>.Register(MoreInfo);

        }
        public InfoPageViewModel()
        {
          
            var coin = Store<CoinsDTO>.Get();
            Image = coin.Image;
            GoToTradePage = new Command(GoToTrade);
            var saved = Store<MoreInfoCoins>.GetOrNull();
            if (saved?.Id.ToLower()!=coin.Id.ToLower()) //Снижаем нагрузку на API при переходе от трейда сюда (меньше запросв дольше можно прожить на пробной версии)
                LoadData(coin.Id);
            else
                MoreInfo = saved;



        }
        public async void GoToTrade(object obj)
        {
            Store<TickerDTO[]>.Register(moreInfo.Tickers);
            await Navigate.GoToAsync(nameof(TradePageView));
        }
        public string Image { get; }
       
        private MoreInfoCoins moreInfo;

        public MoreInfoCoins MoreInfo
        {
            get => moreInfo;
            set => SetProperty(ref moreInfo, value);
        }

    }
}
