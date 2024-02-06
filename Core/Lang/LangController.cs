using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace NewCryptoApp.Core.Lang
{
    public class CultureLang
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
    public class LanguageManager : INotifyPropertyChanged
    {
        public static readonly ObservableCollection<CultureLang> Lang = new ObservableCollection<CultureLang>()
        {
            new CultureLang(){Name = "Українська", Code ="ua"},
            new CultureLang(){Name = "English", Code ="en"},
        };
        private string selectedLanguage;

        public string SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                if (selectedLanguage != value)
                {
                    selectedLanguage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedLanguage)));
                    UpdateLanguageResources();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateLanguageResources()
        {

            Application.Current.Resources.MergedDictionaries.Clear();
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri($"Core/Lang/Resources.{SelectedLanguage}.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
