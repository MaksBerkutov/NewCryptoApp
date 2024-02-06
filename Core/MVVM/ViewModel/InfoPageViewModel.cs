using NewCryptoApp.Core.API.CoinGesko.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class InfoPageViewModel:ViewModel
    {
        public CoinsDTO SelectedDto {  get; set; }
        public InfoPageViewModel()
        {
        }
    }
}
