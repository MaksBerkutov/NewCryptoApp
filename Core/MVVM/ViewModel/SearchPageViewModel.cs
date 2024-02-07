using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    class SearchPageViewModel: ViewModel
    {
        public Command FindCmd { get; }

        public SearchPageViewModel()
		{
			FindCmd = new Command(Find, (_) => search != "");
		}
		private async void Find(object obj)
		{
            var findDto = await CoinGeskoAPI.FindCoins(search);
            FindCoins = findDto.Coins;
            FindExchanges = findDto.Exchanges; 
            FindNfts = findDto.Nfts;

        }

        private string search = "";

		public string Search
		{
			get => search;
			set => SetProperty(ref search, value);
		}





		private FindCoinsDTO[] findCoins;

		public FindCoinsDTO[] FindCoins
		{
			get => findCoins;

            set => SetProperty(ref findCoins, value);
		}

        private FindCoinsDTO selectedCoin;

        public FindCoinsDTO SelectedCoin
        {
            get => selectedCoin;
            set => SetProperty(ref selectedCoin, value);
        }




        private FindExchangesDTO[] findExchanges;

        public FindExchangesDTO[] FindExchanges
        {
            get => findExchanges;

            set => SetProperty(ref findExchanges, value);
        }
        private FindExchangesDTO selectedExchanges;

        public FindExchangesDTO SelectedExchanges
        {
            get => selectedExchanges;
            set => SetProperty(ref selectedExchanges, value);
        }


        private FindNftDTO[] findNfts;

        public FindNftDTO[] FindNfts
        {
            get => findNfts;

            set => SetProperty(ref findNfts, value);
        }

        private FindNftDTO selectedNft;

        public FindNftDTO SelectedNft
        {
            get => selectedNft;
            set => SetProperty(ref selectedNft, value);
        }

    }
}
