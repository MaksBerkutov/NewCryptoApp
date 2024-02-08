using NewCryptoApp.Core.MVVM.View;
using NewCryptoApp.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NewCryptoApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Navigate.RegisterStaticPage<MainPageView>();
            Navigate.RegisterPage<InfoPageView>();
            Navigate.RegisterPage<SearchPageView>();
            Navigate.RegisterPage<ChartPageView>();
            Navigate.RegisterPage<MoreInfoExchangesView>();
            Navigate.RegisterPage<TradePageView>();
        }
    }
}
