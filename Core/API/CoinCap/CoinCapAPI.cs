using NewCryptoApp.Core.API.CoinCap.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API.CoinCap
{
    public class CoinCapAPI
    {
        private readonly static BaseAPI instance = new BaseAPI("https://api.coincap.io/v2", nameof(CoinCapAPI));
        public static async Task<ICollection< CandelsOHLcDTO>> GetChartPoint(string CoinId, string ValuteName = "USD", long StartUnixTime = 0, long EndUnixTime = 0)
        {
            return await instance.StandartHandler<List<CandelsOHLcDTO>>($"candles?baseId={CoinId}&quoteId={ValuteName}&start={StartUnixTime}&start={EndUnixTime}", (template) =>
            {
                return template.data.ToString();
            });
        }
        public static async Task<ICollection<ValuteDTO>> GetValute()
        {
            return await instance.StandartHandler<List<ValuteDTO>>("rates", (template) =>
            {
                return template.data.ToString();
            });
        }
        public static async Task<ICollection<CoinDTO>> GetCoins(int Limit = 1000)
        {
            return await instance.StandartHandler<List<CoinDTO>>($"assets?limit={Limit}", (template) =>
            {
                return template.data.ToString();
            });
        }

    }
}
