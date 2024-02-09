using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API.CoinCap.Model
{
    public class CoinDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "priceUsd")]
        public double? PriceUSD { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        public override string ToString() => Symbol;
    }
}
