using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CryptoCompare.Model
{
    public class ChartHistoryPointDTO
    {
        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "high")]
        public double High { get; set; }

        [JsonProperty(PropertyName = "low")]
        public double Low { get; set; }

        [JsonProperty(PropertyName = "open")]
        public double Open { get; set; }

        [JsonProperty(PropertyName = "close")]
        public double Close { get; set; }

        [JsonProperty(PropertyName = "volumefrom")]
        public double VolumeFrom { get; set; }

        [JsonProperty(PropertyName = "volumeto")]
        public double VolumeTo { get; set; }
    }


}
