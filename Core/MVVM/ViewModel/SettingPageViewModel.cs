using NewCryptoApp.Core.GeneralModel;
using NewCryptoApp.Core.Lang;
using NewCryptoApp.Core.Theme;
using System.Linq;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class SettingPageViewModel:ViewModel
    {
        public SettingPageViewModel()
        {
            SelectedLang = AllLang.ToList().Find(x => x.Code == LanguageController.CurrentCode);
            SelectedTheme = AllTheme.ToList().Find(x => x.Code == ThemeController.CurrentCode);
        }
        private ResourcesModel[] allLang = LanguageController.Lang;
		public ResourcesModel[] AllLang
        {
			get => allLang;
			set => SetProperty(ref allLang, value);
		}

		private ResourcesModel selectedLang;

		public ResourcesModel SelectedLang
        {
            get => selectedLang;
            set
			{
                SetProperty(ref selectedLang, value);
                LanguageController.CurrentCode = selectedLang.Code;
            }
        }


        private ResourcesModel[] allTheme = ThemeController.Theme;
        public ResourcesModel[] AllTheme
        {
            get => allTheme;
            set => SetProperty(ref allTheme, value);
        }

        private ResourcesModel selectedTheme;

        public ResourcesModel SelectedTheme
        {
            get => selectedTheme;
            set
            {
                SetProperty(ref selectedTheme, value);
                ThemeController.CurrentCode = selectedTheme.Code;
            }
        }


    }
}
