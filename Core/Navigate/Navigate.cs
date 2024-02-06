using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewCryptoApp.Core.Navigate
{
    public static class Navigate
    {
        public static Frame CurrentFrame { get; set; }

        private static List<Type> RegisterPages = new List<Type>();
        public static void RegisterFrame(ref Frame frame)
        {
            CurrentFrame = frame;
        }
        public static void RegisterPage<T>() where T : Page
        {
            var finded = RegisterPages.Find(type => type == typeof(T));
            if (finded == null)
                RegisterPages.Add(typeof(T));
        }
      
        public static void GoTo(string PageName)
        {
            var finded = RegisterPages.Find(type => type.Name == PageName);
            if (finded == null) return;
            Application.Current.Dispatcher.Invoke(() =>
            {
                CurrentFrame.Content = Activator.CreateInstance(finded);
            });
        }
        public static async Task GoToAsync(string PageName)
        {

            var finded = RegisterPages.Find(type => type.Name == PageName);
            if (finded == null) return;
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                CurrentFrame.Content = Activator.CreateInstance(finded);
            });
        }
    }
}
