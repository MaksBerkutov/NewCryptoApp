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
        protected readonly Logger.Logger logger;
        public BaseAPI(string serverUri,string moduleName):base()
        {
            
            logger = new Logger.Logger(moduleName);
            ServerUri = serverUri;
        }
      
        public async Task<Respones<T>> GetAsync<T>(string routePath) where T : class 
        {
          
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{ServerUri}/{routePath}");
                    HttpResponseMessage response = await SendAsync(request);

                    if (!response.IsSuccessStatusCode)
                    {
                        var ex = new ApiException(response.StatusCode, response.ReasonPhrase, request.RequestUri.ToString());
                        await logger.Write(ex);
                        return new Respones<T>(error: ex);
                       
                    }
                    string content = await response.Content.ReadAsStringAsync();
                    var resultData = JsonConvert.DeserializeObject<T>(content);
                    return new Respones<T>(result: resultData);
                }
                catch (Exception ex)
                {
                    await logger.Write(ex);
                    return new Respones<T>(error: ex);
                }
            }

        
        
    }
}
