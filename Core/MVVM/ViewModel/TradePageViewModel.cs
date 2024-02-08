using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.MVVM.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class TradePageViewModel : ViewModel
    {
        public Command ClearFilter { get; }
        public Command GoToTrade { get; }
        public Command GoToMoreInfoExch { get; }
        public Command Back { get; }
        public TradePageViewModel()
        {
            ClearFilter = new Command(FilterClear);
            GoToTrade = new Command(
                (_) => Process.Start(selectedTicker.TradeUrl),
                (_) => selectedTicker != null
                );
            Back = new Command(

               async (_) =>
               {
                   Store<TickerDTO[]>.Clear();
                   await Navigate.GoToAsync(nameof(InfoPageView));
               }
               );
            GoToMoreInfoExch = new Command(async (_) =>
            {
                Store<MarketDTO>.Register(selectedTicker.Market);
                await Navigate.GoToAsync(nameof(MoreInfoExchangesView));
            },
             (_) => selectedTicker != null);
            Tickers = Store<TickerDTO[]>.Get();
            BaseCoin = Tickers.ToList().Select(item=>item.Base).Distinct().ToArray();
            TargetCoin = Tickers.ToList().Select(item => item.Target).Distinct().ToArray();
            Filter();
        }
        private void FilterClear(object obj)
        {
            SelectedBaseCoin = null;
            SelectedTargetCoin = null;
        }
        private void Filter()
        {
            FilterTickers = Tickers.ToList().FindAll(element =>
            {
                if(selectedTargetCoin == null&& selectedBaseCoin == null)
                    return true;
                if(selectedTargetCoin == null && selectedBaseCoin != null)
                {
                    return element.Base == selectedBaseCoin;
                }
                else if (selectedTargetCoin != null && selectedBaseCoin == null)
                {
                    return element.Target == selectedTargetCoin;
                }
                else
                {
                    return element.Target == selectedTargetCoin && element.Base == selectedBaseCoin;
                }

            }).ToArray();
        }

        private TickerDTO selectedTicker;

        public TickerDTO SelectedTicker
        {
            get => selectedTicker;
            set => SetProperty(ref selectedTicker, value);
        }

        private string[] baseCoin;

        public string[] BaseCoin
        {
            get => baseCoin;
            set => SetProperty(ref baseCoin, value);
        }
        private string selectedBaseCoin;

        public string SelectedBaseCoin
        {
            get => selectedBaseCoin;
            set
            {
                SetProperty(ref selectedBaseCoin, value);
                Filter();
            }
        }

        private string[] targetCoin;

        public string[] TargetCoin
        {
            get => targetCoin;
            set => SetProperty(ref targetCoin, value);
        }
        private string selectedTargetCoin;

        public string SelectedTargetCoin
        {
            get => selectedTargetCoin;
            set 
            { 
                SetProperty(ref selectedTargetCoin, value);
                Filter();
            }
        }


        private TickerDTO[] tickers;

        public TickerDTO[] Tickers
        {
            get => tickers;
            set => SetProperty(ref tickers, value);
        }

        private TickerDTO[] filterTickers;

        public TickerDTO[] FilterTickers
        {
            get => filterTickers;
            set => SetProperty(ref filterTickers, value);
        }

    }
}
