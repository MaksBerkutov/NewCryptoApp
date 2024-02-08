using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class ConvertedDTO
    {
        [JsonProperty(PropertyName = "btc")]
        public string BTC { get; set; }

        [JsonProperty(PropertyName = "eth")]
        public string ETH { get; set; }

        [JsonProperty(PropertyName = "usd")]
        public string USD { get; set; }

    }

}
