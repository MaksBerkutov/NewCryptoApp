using NewCryptoApp.Core.API.CoinGesko.Model;
using NewCryptoApp.Core.API.CoinGesko;
using System.Diagnostics;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class MoreNftViewModel: ViewModel
    {
        public Command Back { get; }
        public Command OpenExternalLink { get; }
        public async void LoadData(string Id)
        {
            InfoNft = await CoinGeskoAPI.GetMoreInfoNft(Id);
            Store.Register(InfoNft);
        }
        public MoreNftViewModel()
        {
            var findNft = Store.Get<FindNftDTO>();
            Image = findNft.Image;  
            Back = new Command(async (_) => await Navigate.Back());
            OpenExternalLink = new Command((Link) => Process.Start(Link as string));
            LoadData(findNft.Id);
        }

        private string image;

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private MoreInfoNftDTO infoNft;
        public MoreInfoNftDTO InfoNft
        {
            get => infoNft;
            set => SetProperty(ref infoNft, value); 
        }

    }
}
