using NewCryptoApp.Core.API.APIException;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewCryptoApp.Core.API
{
    class BaseAPI: HttpClient
    {
        public readonly string ServerUri;
        protected readonly Logger logger;
        public BaseAPI(string serverUri,string moduleName):base()
        {
            
            logger = new Logger(moduleName);
            ServerUri = serverUri;
        }

        public async Task<Respones<T>> GetAsync<T>(string routePath) where T : class
        {
           
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{ServerUri}/{routePath}");
                    DefaultRequestHeaders.Add("User-Agent",
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0");
                    HttpResponseMessage response = await SendAsync(request);

                    if (!response.IsSuccessStatusCode)
                    {
                        var ex = new ApiException(response.StatusCode, response.ReasonPhrase, request.RequestUri.ToString());
                        await logger.WriteAsync(ex);
                        return new Respones<T>(error: ex);

                    }
                    string content = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<T>(content);
                    return new Respones<T>(result: resultData);
                }
                catch (Exception ex)
                {
                    await logger.WriteAsync(ex);
                    return new Respones<T>(error: ex);
                }
            }
        

        
        
    }
}
