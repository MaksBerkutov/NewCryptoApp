using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class DescriptionDTO
    {
        [JsonProperty(PropertyName = "en")]
        public string En { get; set; }
        public override string ToString() => En;
    }

}
