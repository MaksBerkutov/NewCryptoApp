using Newtonsoft.Json;
using System;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class CoinsDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "current_price")]
        public string Price { get; set; }
        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
    }
}
