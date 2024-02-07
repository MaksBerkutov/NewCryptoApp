using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static NewCryptoApp.Core.Navigate;

namespace NewCryptoApp.Core
{
    public static class Navigate
    {
        //public static object CurrentContent { get; set; }
        private readonly static Logger logger = new Logger(nameof(Navigate));
        private readonly static List<Type> RegisterPages = new List<Type>();
        public delegate void OpenPage(object content);
        public static event OpenPage OnOpenPage;
        public static void RegisterFrame(object content)
        {
            //CurrentContent = content;
        }
        public static string LasPage { get; private set; }
        public static void RegisterPage<T>() where T : Page
        {
            var finded = RegisterPages.Find(type => type == typeof(T));
            if (finded == null)
                RegisterPages.Add(typeof(T));
        }
      
        public static void GoTo(string PageName)
        {
            var finded = RegisterPages.Find(type => type.Name == PageName);
            if (finded == null)
            {
                logger.Write($"Попытка вызвать незарегистрированную форму {PageName}", LoggerType.Error);
                return;
            }
            Application.Current.Dispatcher.Invoke(() =>
            {
                LasPage = PageName;
                OnOpenPage?.Invoke( Activator.CreateInstance(finded));
            });
        }
        public static void GoTo(string PageName, params object[] args)
        {
            var finded = RegisterPages.Find(type => type.Name == PageName);
            if (finded == null) {
                logger.Write($"Попытка вызвать незарегистрированную форму {PageName}",LoggerType.Error);
                return;
            }
            
            Application.Current.Dispatcher.Invoke(() =>
            {
                LasPage = PageName;
                OnOpenPage?.Invoke(Activator.CreateInstance(finded, args));
            });
        }
        public static async Task GoToAsync(string PageName)
        {

            var finded = RegisterPages.Find(type => type.Name == PageName);
            if (finded == null)
            {
                await logger.WriteAsync($"Попытка вызвать незарегистрированную форму {PageName}", LoggerType.Error);
                return;
            }
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                LasPage = PageName;
                OnOpenPage?.Invoke(Activator.CreateInstance(finded));
            });
        }
        public static async Task GoToAsync(string PageName, params object[] args)
        {

            var finded = RegisterPages.Find(type => type.Name == PageName);
            if (finded == null) return;
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                LasPage = PageName;
                OnOpenPage?.Invoke(Activator.CreateInstance(finded, args));
            });
        }
    }
}
