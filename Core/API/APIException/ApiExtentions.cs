using System;
using System.Net;

namespace NewCryptoApp.Core.API.APIException
{
    class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string RequestUri { get; }
        public ApiException(HttpStatusCode statusCode, string message, string requestUri) : base(message)
        {
            StatusCode = statusCode;
            RequestUri = requestUri;
        }

       
    }
}
