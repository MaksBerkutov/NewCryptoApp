using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CryptoCompare.Model
{
    public class ChartHistoryDTO
    {
        public long TimeFrom { get; set; }
        public long TimeTo { get; set; }

        [JsonProperty(PropertyName = "Data")]
        public ChartHistoryPointDTO[] ChartPoint { get; set; }
    }


}
