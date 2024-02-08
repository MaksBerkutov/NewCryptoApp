using NewCryptoApp.Core.API.CoinGesko.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API.CoinGesko
{
     class CoinGeskoAPI
    {
        private readonly static BaseAPI instance = new BaseAPI("https://api.coingecko.com/api/v3", nameof(CoinGeskoAPI));
       
 
      
        public static async Task<ICollection<CoinsDTO>> GetTopCoins(int limit = 10)
        {
            return await instance.StandartHandler<List<CoinsDTO>>($"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={limit}&page=1");
        }

        public static async Task<FindDTO> FindCoins(string query)
        {
            return await instance.StandartHandler<FindDTO>($"search?query={query}");
        }

        public static async Task<MoreInfoCoins> GetMoreInfoCoin(string id)
        {
            return await instance.StandartHandler<MoreInfoCoins>($"coins/{id}?localization=false&tickers=true&market_data=false&community_data=false&developer_data=false&sparkline=false");
        }
        public static async Task<MoreInfoExchangesDTO> GetMoreInfoExchange(string id)
        {
            return await instance.StandartHandler<MoreInfoExchangesDTO>($"exchanges/{id}");
        }
    }
}
