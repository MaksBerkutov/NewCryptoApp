using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewCryptoApp.Core
{
    public static class Navigate
    {
        private readonly static Logger logger = new Logger(nameof(Navigate));
        private readonly static List<Type> RegisterPages = new List<Type>();
        public delegate void OpenPage(object content);
        public static event OpenPage OnOpenPage;
        private static readonly List<Type> RegisterStaticPages = new List<Type>();
        private static readonly Stack<string> History = new Stack<string>();
        public static string LasPage { get; private set; }
        public static void RegisterPage<T>() where T : Page
        {
            var finded = RegisterPages.Find(type => type == typeof(T));
            if (finded == null)
                RegisterPages.Add(typeof(T));
        }
        public static async Task Back()
        {
            History.Pop(); //Удлаляем текущюю страницу

            if (History.Count == 0) return;
            await GoToAsync(History.Pop()); //Удлаляем слдующюю страницу, ведь при добавлении она заново появиться в стеке.
        }
        public static void RegisterStaticPage<T>() where T : Page
        {
            var finded = RegisterStaticPages.Find(type => type == typeof(T));
            if (finded == null)
                RegisterStaticPages.Add(typeof(T));
        }
        private static Type FindPageByName(string PageName)
        {
            return RegisterPages.Concat(RegisterStaticPages).ToList().Find(type => type.Name == PageName);
        }
        private static void IsStatic(string PageName)
        {
            LasPage = PageName;
            var pages =  RegisterStaticPages.Find(type => type.Name == PageName);
            if (pages != null)
            {
                Store.ClearAll();
                History.Clear();
            }

            History.Push(PageName);
        }
        public static void GoTo(string PageName)
        {
            var pages = FindPageByName(PageName);
            if (pages == null)
            {
                logger.Write($"Попытка вызвать незарегистрированную форму {PageName}", LoggerType.Error);
                return;
            }
            Application.Current.Dispatcher.Invoke(() =>
            {
                IsStatic(PageName);
                OnOpenPage?.Invoke( Activator.CreateInstance(pages));
            });
        }
        public static void GoTo(string PageName, params object[] args)
        {
            var pages = FindPageByName(PageName);
            if (pages == null) {
                logger.Write($"Попытка вызвать незарегистрированную форму {PageName}",LoggerType.Error);
                return;
            }
            
            Application.Current.Dispatcher.Invoke(() =>
            {
                IsStatic(PageName);
                OnOpenPage?.Invoke(Activator.CreateInstance(pages, args));
            });
        }
        public static async Task GoToAsync(string PageName)
        {

            var pages = FindPageByName(PageName);
            if (pages == null)
            {
                await logger.WriteAsync($"Попытка вызвать незарегистрированную форму {PageName}", LoggerType.Error);
                return;
            }
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                IsStatic(PageName);
                OnOpenPage?.Invoke(Activator.CreateInstance(pages));
            });
        }
        public static async Task GoToAsync(string PageName, params object[] args)
        {

            var pages = FindPageByName(PageName);
            if (pages == null)
            {
                await logger.WriteAsync($"Попытка вызвать незарегистрированную форму {PageName}", LoggerType.Error);
                return;
            }
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                IsStatic(PageName);
                OnOpenPage?.Invoke(Activator.CreateInstance(pages, args));
            });
        }
    }
}
