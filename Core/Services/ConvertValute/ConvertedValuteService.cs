using NewCryptoApp.Core.API.CoinCap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.Services
{
    public class ConvertedValuteService
    {
        private static double GetCurse(double From, double To) => From / To;
        public static string ConvertValuteToCoin(ValuteDTO From,CoinDTO To, double Count)
        {
            if (To.PriceUSD == null) return "";
            var curse = GetCurse(Math.Round(From.PriceUSD.Value,3), Math.Round(To.PriceUSD.Value,3));
            return (Count*curse).ToString();
        }
        public static string ConvertCoinToValute(CoinDTO From, ValuteDTO To, double Count)
        {
           
            if (From.PriceUSD == null) return "";
            var curse = GetCurse(Math.Round(From.PriceUSD.Value,3), Math.Round(To.PriceUSD.Value, 3));
            return (Count * curse).ToString();
        }
    }
}
