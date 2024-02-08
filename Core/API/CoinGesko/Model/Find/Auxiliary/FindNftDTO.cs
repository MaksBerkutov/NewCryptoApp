using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NewCryptoApp.Core.API.CoinGesko.Model
{
    public class FindNftDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "thumb")]
        private string image;
        public string Image 
        {
            get
            {
                if (!image.StartsWith("http"))return "https://icons.veryicon.com/png/o/miscellaneous/myicon-1/none-1.png";
                return image.Replace("thumb", "large");                
            }
            set => image = value;
        }
        //Заметил что api в Nft возвращяет только thumb изображения, но если заменить в ссылке с thumb на large то как и пологаеться вернёться картинка нормального размера для отображения
        //Так что использую пока так.


        public override string ToString() => Name;
    }
}
