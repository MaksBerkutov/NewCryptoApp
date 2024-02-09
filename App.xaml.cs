using NewCryptoApp.Core.MVVM.View;
using NewCryptoApp.Core;
using NewCryptoApp.Core.Lang;
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
            LanguageManager.CurrentCode = "en";
            Navigate.RegisterStaticPage<MainPageView>();
            Navigate.RegisterStaticPage<SettingPageView>();
            Navigate.RegisterStaticPage<ConvertorPageView>();
            Navigate.RegisterPage<InfoPageView>();
            Navigate.RegisterPage<SearchPageView>();
            Navigate.RegisterPage<ChartPageView>();
            Navigate.RegisterPage<MoreNftView>();
            Navigate.RegisterPage<MoreInfoExchangesView>();
            Navigate.RegisterPage<TradePageView>();
        }
    }
}
