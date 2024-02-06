using NewCryptoApp.Core.API.APIException;
using System;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.Logger
{
    enum LoggerType
    {
        Info,
        Message,
        Error
    }
    class Logger
    {
        public readonly string ModuleName;

        public Logger(string moduleName)
        {
            ModuleName = moduleName;
        }
        private static void Write(string message)
        {
            Console.WriteLine(message);
        }
        public async Task Write(string message,LoggerType type)
        {
            await Task.Run(() =>
            {
                Write($"{DateTime.Now}) ({ModuleName}) {message} [{type}]");
            });
        }
        public async Task Write(Exception ex)
        {
            await Task.Run(() =>
            {
                if (ex is ApiException)
                {
                    var ApiEx = ex as ApiException;
                    Write($"{DateTime.Now}) ({ModuleName}) Ошибка выполнения запроса по {ApiEx.RequestUri}  {ApiEx.Message} [Api Error | {ApiEx.StatusCode}]");
                }
                else
                    Write($"{DateTime.Now}) ({ModuleName}) {ex.Message} [Error]");

            });
        }
    }
}
