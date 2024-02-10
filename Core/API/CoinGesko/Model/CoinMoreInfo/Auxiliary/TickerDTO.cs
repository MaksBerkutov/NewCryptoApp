using Newtonsoft.Json;
using System;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class TickerDTO
    {
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        [JsonProperty(PropertyName = "target")]
        public string Target { get; set; }

        [JsonProperty(PropertyName = "market")]
        public MarketDTO Market { get; set; }

        [JsonProperty(PropertyName = "last")]
        public double? Last { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public double? Volume { get; set; }

        [JsonProperty(PropertyName = "converted_last")]
        public ConvertedDTO ConvertedLast { get; set; }

        [JsonProperty(PropertyName = "converted_volume")]
        public ConvertedDTO ConvertedVolume { get; set; }

        [JsonProperty(PropertyName = "trust_score")]
        public string TrustScore { get; set; }

        [JsonProperty(PropertyName = "bid_ask_spread_percentage")]
        public double? BidAskSpreadPercentage { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty(PropertyName = "last_fetch_at")]
        public DateTime? LastFetch { get; set; }

        [JsonProperty(PropertyName = "last_traded_at")]
        public DateTime? LastTraded { get; set; }

        [JsonProperty(PropertyName = "trade_url")]
        public string TradeUrl { get; set; }

    }

}
