﻿using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class FindCoinsDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "market_cap_rank")]
        public int? MarketCupRank { get; set; }

        [JsonProperty(PropertyName = "large")]
        public string Image { get; set; }

    }
}
