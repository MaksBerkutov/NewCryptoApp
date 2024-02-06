using NewCryptoApp.Core.API.CoinGesko.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API.CoinGesko
{
     class CoinGeskoAPI
    {
        private readonly static BaseAPI instance = new BaseAPI("https://api.coingecko.com/api/v3", nameof(CoinGeskoAPI));
       
        public static async Task<CoinsDTO[]> GetTopCoins(int limit = 10)
        {
            var response = await instance.GetAsync<CoinsDTO[]>($"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={limit}&page=1");
            if(!response.Successful) throw response.Error;

            return response.Result;
        }
    }
}
