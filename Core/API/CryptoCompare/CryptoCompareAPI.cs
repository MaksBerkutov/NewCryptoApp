using NewCryptoApp.Core.API.CryptoCompare.Model;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API.CryptoCompare
{
    public class CryptoCompareAPI
    {
        private readonly static BaseAPI instance = new BaseAPI("https://min-api.cryptocompare.com/data/v2", nameof(CryptoCompareAPI));
        public static async Task<ChartHistoryDTO> GetChartPoint(string CoinId,string ValuteName = "USD",int LimitPoint = 750)
        {
            return await instance.StandartHandler<ChartHistoryDTO>($"histoday?fsym={CoinId}&tsym={ValuteName}&limit={LimitPoint}", (template) =>
            {
                return template.Data.ToString();
            });
        }
    }
}
