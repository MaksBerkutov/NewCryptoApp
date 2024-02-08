using NewCryptoApp.Core.API.CoinGesko.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API.CoinGesko
{
     class CoinGeskoAPI
    {
        private readonly static BaseAPI instance = new BaseAPI("https://api.coingecko.com/api/v3", nameof(CoinGeskoAPI));
       
 
      
        public static async Task<ICollection<CoinsDTO>> GetTopCoins(int Limit = 10)
        {
            if (Limit <= 0) Limit = 10;
            return await instance.StandartHandler<List<CoinsDTO>>($"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={Limit}&page=1");
        }

        public static async Task<FindDTO> FindCoins(string Query)
        {
            return await instance.StandartHandler<FindDTO>($"search?query={Query}");
        }

        public static async Task<MoreInfoCoinsDTO> GetMoreInfoCoin(string CoinId)
        {
            return await instance.StandartHandler<MoreInfoCoinsDTO>($"coins/{CoinId}?localization=false&tickers=true&market_data=false&community_data=false&developer_data=false&sparkline=false");
        }
        public static async Task<MoreInfoExchangesDTO> GetMoreInfoExchange(string ExchangeId)
        {
            return await instance.StandartHandler<MoreInfoExchangesDTO>($"exchanges/{ExchangeId}");
        }

        public static async Task<ChartDTO> GetChartPoint(string CoinId,string Valute = "usd",long Minimum = 0, long Maximum = 0)
        {
            var unixTimestamp = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
            if (Maximum == 0 || Maximum > unixTimestamp) Maximum = unixTimestamp;
            if (Minimum < 0)   Minimum = 0;
            return await instance.StandartHandler<ChartDTO>($"coins/{CoinId}/market_chart/range?vs_currency={Valute.ToLower()}&from={Minimum}&to={Maximum}");
        }
    }
}
