using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinCap.Model
{
    public class ValuteDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "rateUsd")]
        public double? PriceUSD { get; set; }

        [JsonProperty(PropertyName = "currencySymbol")]
        public string UNIXLogo { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        public override string ToString() => Symbol;

    }
}
