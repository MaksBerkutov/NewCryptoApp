using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class MoreInfoExchangesDTO
    {
        [JsonProperty(PropertyName = "name")] 
        public string Name { get; set; }

        [JsonProperty(PropertyName = "image")] 
        public string Image { get; set; }

        [JsonProperty(PropertyName = "centralized")]
        public bool Centralized { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "facebook_url")]
        public string FacebookUrl { get; set; }

        [JsonProperty(PropertyName = "reddit_url")]
        public string RedditUrl { get; set; }

        [JsonProperty(PropertyName = "telegram_url")]
        public string TelegramUrl { get; set; }

        [JsonProperty(PropertyName = "twitter_handle")]
        public string TwitterUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string MainUrl { get; set; }

        [JsonProperty(PropertyName = "trust_score")]
        public int TrustScore { get; set; }

        [JsonProperty(PropertyName = "trust_score_rank")]
        public int TrustScoreRank { get; set; }

        [JsonProperty(PropertyName = "year_established")]
        public string YearEstablished { get; set; }

    }
}
