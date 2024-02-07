using Newtonsoft.Json;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class FindDTO
    {
        [JsonProperty(PropertyName = "coins")]
        public FindCoinsDTO[] Coins { get; set; }
        [JsonProperty(PropertyName = "exchanges")]
        public FindExchangesDTO[] Exchanges { get; set; }

        [JsonProperty(PropertyName = "nfts")]
        public FindNftDTO[] Nfts { get; set; }

        public FindDTO() {
            Coins = new FindCoinsDTO[0];
            Exchanges = new FindExchangesDTO[0];
            Nfts = new FindNftDTO[0];
        }


    }
}
