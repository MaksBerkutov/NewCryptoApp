using Newtonsoft.Json;
using System;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class MoreInfoCoinsDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "web_slug")]
        public string WebSlug { get; set; }

        [JsonProperty(PropertyName = "block_time_in_minutes")] 
        public int BlockTimeMinutes { get; set; }

        [JsonProperty(PropertyName = "hashing_algorithm")] 
        public string HashingAlgorithm { get; set; }

        [JsonProperty(PropertyName = "country_origin")]
        public string CountryOrigin { get; set; }

        [JsonProperty(PropertyName = "genesis_date")]
        public DateTime? Genesisdate { get; set; } = DateTime.MinValue;

        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdate { get; set; } = DateTime.MinValue;

        [JsonProperty(PropertyName = "sentiment_votes_down_percentage")]
        public double SentimentVotesDown { get; set; }

        [JsonProperty(PropertyName = "sentiment_votes_up_percentage")]
        public double SentimentVotesUp { get; set; }


        [JsonProperty(PropertyName = "description")]
        public DescriptionDTO Description { get; set; } = new DescriptionDTO() ;

        [JsonProperty(PropertyName = "categories")]
        public string[] Categories { get; set; } = new string[0];

        [JsonProperty(PropertyName = "tickers")]
        public TickerDTO[] Tickers { get; set; } = new TickerDTO[0];


    }

}
