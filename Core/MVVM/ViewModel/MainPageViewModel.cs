using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.MVVM.View;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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
            Update = new Command(UpdateItems, (obj) => limit > 0);
            ToGraphics = new Command(GoToGraphics, (obj) => selectedCoin != null);
            ToInfo = new Command(GoToGraphics, (obj) => selectedCoin != null);
        }
        public async void GoToGraphics(object obj = null)
        {
            await Navigate.GoToAsync(nameof(InfoPageView), SelectedCoin);
        }
        public async void UpdateItems(object obj = null)
        {
            try
            {
                var newArrayCoins = await CoinGeskoAPI.GetTopCoins(limit: limit);
                ArrayCoins = newArrayCoins;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        private CoinsDTO[] arrayCoins;

        public CoinsDTO[] ArrayCoins
        {
            get => arrayCoins;
            set => SetProperty(ref arrayCoins, value, nameof(ArrayCoins));
        }

        private CoinsDTO selectedCoin = null;

        public CoinsDTO SelectedCoin
        {
            get => selectedCoin;
            set => SetProperty(ref selectedCoin, value, nameof(SelectedCoin)); 
             
        }
        





    }
}
