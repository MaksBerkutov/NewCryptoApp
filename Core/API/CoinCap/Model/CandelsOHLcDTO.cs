using Newtonsoft.Json;


namespace NewCryptoApp.Core.API.CoinCap.Model
{
    public class CandelsOHLcDTO
    {
        [JsonProperty(PropertyName = "open")]
        public double Open { get; set; }

        [JsonProperty(PropertyName = "high")]
        public double High { get; set; }

        [JsonProperty(PropertyName = "low")]
        public double Low { get; set; }

        [JsonProperty(PropertyName = "close")]
        public double Close { get; set; }
        [JsonProperty(PropertyName = "volume")]
        public double Volume { get; set; }
        [JsonProperty(PropertyName = "period")]
        public double Time { get; set; }
    }
}
