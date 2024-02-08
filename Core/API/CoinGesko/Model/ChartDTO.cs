using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class ChartDTO
    {
        [JsonProperty(PropertyName = "market_caps")]
        public List<List<long>> MarketCaps { get; set; }

        [JsonProperty(PropertyName = "prices")]
        public List<List<long>> Prices { get; set; }

        [JsonProperty(PropertyName = "total_volumes")]
        public List<List<long>> TotalVolumes { get; set; }
    }

}




