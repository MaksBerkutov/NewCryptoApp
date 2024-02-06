using System;

namespace NewCryptoApp.Core.API
{
    class Respones<T> where T : class
    {
        public bool Successful => Result == null;
        public readonly Exception Error;
        public readonly T Result;

        public Respones(Exception error = null, T result = null)
        {
            if (error == null && result == null)
                throw new Exception("Ответ должен содержать или исключене или результат.");
            Error = error;
            Result = result;
        }

    }
}
