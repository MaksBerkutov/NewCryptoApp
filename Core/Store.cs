using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCryptoApp.Core
{
    static class Store<T>where T : class
    {
        private readonly static List<object> StoreItem = new List<object>();

        public static void Register(T StoreData)
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded == -1)
                StoreItem.Add(StoreData);
            else
                StoreItem[finded] = StoreData;

        }
        public static T Get()
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded != -1)
               return (T)StoreItem[finded];
            throw new Exception($"Попытка получения незарегистрованного объекта ({typeof(T).Name})");
        }
        public static T GetOrNull()
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded != -1)
                return (T)StoreItem[finded];
            return null;
        }

        public static void Clear()
        {
            var finded = StoreItem.FindIndex(item => item.GetType().Name == typeof(T).Name);
            if (finded != -1)
                StoreItem.RemoveAt(finded); 
        }

    }
}
