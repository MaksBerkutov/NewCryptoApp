using NewCryptoApp.Core.Lang;
using System.Linq;

namespace NewCryptoApp.Core.MVVM.ViewModel
{
    public class SettingPageViewModel:ViewModel
    {
        public SettingPageViewModel()
        {
            SelectedLang = AllLang.ToList().Find(x => x.Code == LanguageManager.CurrentCode);
        }
        private CultureLang[] allLang = LanguageManager.Lang;
		public CultureLang[] AllLang
        {
			get => allLang;
			set => SetProperty(ref allLang, value);
		}

		private CultureLang selectedLang;

		public CultureLang SelectedLang
        {
            get => selectedLang;
            set
			{
                SetProperty(ref selectedLang, value);
                LanguageManager.CurrentCode = selectedLang.Code;
            }
        }


	}
}
