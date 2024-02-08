using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core
{
    static class Store
    {
        private readonly static List<object> StoreItem = new List<object>();

        public static void Register<T>(T StoreData) where T : class
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded == -1)
                StoreItem.Add(StoreData);
            else
                StoreItem[finded] = StoreData;

        }
        public static T Get<T>() where T : class
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded != -1)
               return (T)StoreItem[finded];
            throw new Exception($"Попытка получения незарегистрованного объекта ({typeof(T).Name})");
        }
        public static T GetOrNull<T>() where T : class
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded != -1)
                return (T)StoreItem[finded];
            return null;
        }
        public static void ClearAll() => StoreItem.Clear();
        public static void Clear<T>() where T : class
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded != -1)
                StoreItem.RemoveAt(finded); 
        }

    }
}
