using NewCryptoApp.Core.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    class MainWindowViewModel:ViewModel
    {
        public Command GoToSettingPage { get; }
        public Command GoToConverterPage { get; }
        public Command GoToFindPage { get; }
        public Command GoToHomePage { get; }

        // Для того что бы убрать тупой копипаст кода.
        private Command CreateCommandNavigate(string PageName) => new Command(async (_) => await Navigate.GoToAsync(PageName), (_) => Navigate.LasPage != PageName); 
        public MainWindowViewModel()
		{
            GoToHomePage = CreateCommandNavigate(nameof(MainPageView));
            GoToSettingPage = CreateCommandNavigate(nameof(SearchPageView));
            GoToConverterPage = CreateCommandNavigate(nameof(SearchPageView));
            GoToFindPage = CreateCommandNavigate(nameof(SearchPageView));
            Navigate.RegisterPage<MainPageView>();
            Navigate.RegisterPage<InfoPageView>();
            Navigate.RegisterPage<SearchPageView>();
            Navigate.OnOpenPage += Navigate_OnOpenPage;

            Navigate.GoTo(nameof(MainPageView));
        }

        private void Navigate_OnOpenPage(object content)
        {
            Content = content;
        }

        private object content;

		public object Content
		{
			get => content;

            set => SetProperty(ref content, value);
		}

	}
}
