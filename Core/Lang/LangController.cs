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
    public class LanguageManager
    {
        public static readonly CultureLang[] Lang = new CultureLang[]
        {
            new CultureLang(){Name = "Українська", Code ="ua"},
            new CultureLang(){Name = "English", Code ="en"},
            new CultureLang(){Name = "русский", Code ="ru"},
        };
        private static string currentCode;
        public static string CurrentCode
        {
            get => currentCode;
            set
            {
                currentCode = value;
                UpdateLanguageResources();
            }
        }
        private static void UpdateLanguageResources()
        {

            Application.Current.Resources.MergedDictionaries.Clear();
            var resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri($"Core/Lang/Resources.{currentCode}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
