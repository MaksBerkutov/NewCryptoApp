using NewCryptoApp.Core.API.APIException;
using System;
using System.IO;
using System.Threading.Tasks;


namespace NewCryptoApp.Core
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
        const string Filename = "log.log";
        public Logger(string moduleName)
        {
            ModuleName = moduleName;
        }
        private readonly static object _lockObject = new object();

        private static void Write(string message)
        {
            lock (_lockObject)
            {
                using (StreamWriter writer = new StreamWriter(Filename, true))
                {
                    writer.WriteLine(message);
                }
            }
        }
        public void Write(string message, LoggerType type)
        {
            Write($"{DateTime.Now}) ({ModuleName}) {message} [{type}]");
        }
       
        
        public void Write(Exception ex)
        {
            if (ex is ApiException)
            {
                var ApiEx = ex as ApiException;
                Write($"{DateTime.Now}) ({ModuleName}) Ошибка выполнения запроса по {ApiEx.RequestUri}  {ApiEx.Message} [Api Error | {ApiEx.StatusCode}]");
            }
            else
                Write($"{DateTime.Now}) ({ModuleName}) {ex.Message} [Error]");
        }
        public async Task WriteAsync(string message, LoggerType type)
        {
            await Task.Run(() =>
            {
                Write(message, type);
            });
        }
        public async Task WriteAsync(Exception ex)
        {
            await Task.Run(() =>
            {
                Write(ex);

            });
        }

    }
}
