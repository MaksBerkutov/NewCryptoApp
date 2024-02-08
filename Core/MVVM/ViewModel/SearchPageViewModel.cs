using NewCryptoApp.Core.API.CoinGesko;
using NewCryptoApp.Core.API.CoinGesko.Model;
using System.Linq;
using NewCryptoApp.Core.MVVM.View;


namespace NewCryptoApp.Core.MVVM.ViewModel
{
    class SearchPageViewModel: ViewModel
    {
        public Command FindCmd { get; }
        public Command ToMoreCoins { get; }
        public Command ToMoreExchenges { get; }
        public Command ToMoreNft { get; }

        public SearchPageViewModel()
		{
            FindCoins = Store.GetOrNull<FindCoinsDTO[]>();
            FindExchanges = Store.GetOrNull<FindExchangesDTO[]>();
            FindNfts = Store.GetOrNull<FindNftDTO[]>();
            Search = Store.GetOrNull<string>();
			FindCmd = new Command(Find, (_) => search != "");
            ToMoreCoins = new Command(GoToMoreCoin);
            ToMoreExchenges = new Command(GoToExchenges); 

        }
        private async void GoToExchenges(object obj)
        {
            Store.Register(obj as FindExchangesDTO);
            await Navigate.GoToAsync(nameof(MoreInfoExchangesView));
        }
        private async void GoToMoreCoin(object obj)
        {
            Store.Register(obj as FindCoinsDTO);
            await Navigate.GoToAsync(nameof(InfoPageView));
        }
        private async void Find(object obj)
		{
            var findDto = await CoinGeskoAPI.FindCoins(search);
            FindCoins = findDto.Coins;
            FindExchanges = findDto.Exchanges; 
            FindNfts = findDto.Nfts;
            Store.Register(findDto.Coins);
            Store.Register(findDto.Exchanges);
            Store.Register(findDto.Nfts);
            Store.Register(search);

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
