using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class FindExchangesDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "market_type")]
        public string MarketType { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "large")]
        public string Image { get; set; }

        public override string ToString() => Name;
    }
}
