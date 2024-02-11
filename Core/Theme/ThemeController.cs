using NewCryptoApp.Core.GeneralModel;
using System;

using System.Windows;

namespace NewCryptoApp.Core.Theme
{
    internal class ThemeController
    {
        public static readonly ResourcesModel[] Theme = new ResourcesModel[]
       {
            new ResourcesModel(){Name = "drk", Code ="dark"},
            new ResourcesModel(){Name = "wht", Code ="white"},
       };
        private static ResourceDictionary CurrentDictionary;

        private static string currentCode;
        public static string CurrentCode
        {
            get => currentCode;
            set
            {
                currentCode = value;
                UpdateThemeResources();
            }
        }
        private static void UpdateThemeResources()
        {

            Application.Current.Resources.MergedDictionaries.Remove(CurrentDictionary);
            CurrentDictionary = new ResourceDictionary()
            {
                Source = new Uri($"Core/Theme/Resources.{currentCode}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(CurrentDictionary);
        }
    }
}
