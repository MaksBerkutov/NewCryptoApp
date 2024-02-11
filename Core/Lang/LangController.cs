using System;
using System.Windows;
using NewCryptoApp.Core.GeneralModel;

namespace NewCryptoApp.Core.Lang
{

    public class LanguageController
    {
        public static readonly ResourcesModel[] Lang = new ResourcesModel[]
        {
            new ResourcesModel(){Name = "Українська", Code ="ua"},
            new ResourcesModel(){Name = "English", Code ="en"},
            new ResourcesModel(){Name = "русский", Code ="ru"},
        };
        private static ResourceDictionary CurrentDictionary;

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

            Application.Current.Resources.MergedDictionaries.Remove(CurrentDictionary);
            CurrentDictionary = new ResourceDictionary()
            {
                Source = new Uri($"Core/Lang/Resources.{currentCode}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(CurrentDictionary);
            
        }
    }
}
