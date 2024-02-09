using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class MoreInfoNftDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "contract_address")]
        public string ContractAddress { get; set; }

        [JsonProperty(PropertyName = "native_currency")]
        public string NativeCurrency { get; set; }

        [JsonProperty(PropertyName = "native_currency_symbol")]
        public string NativeCurrencySymbol { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Dictionary<string, string> Links { get; set; }

        [JsonProperty(PropertyName = "explorers")]
        public ExternUrlDTO[] ExternUrl { get; set; }

    }
    public class ExternUrlDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }

}
