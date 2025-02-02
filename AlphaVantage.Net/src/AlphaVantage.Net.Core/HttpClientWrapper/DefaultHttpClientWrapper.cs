using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaVantage.Net.Core.HttpClientWrapper
{
    /// <summary>
    /// Default wrapper for <see cref="HttpClient"/> that doesn't contains any additional logic
    /// </summary>
    public class DefaultHttpClientWrapper : IHttpClientWrapper
    {
        private readonly bool _disposeHttpClient;
        private readonly HttpClient _httpClient;

        public DefaultHttpClientWrapper(HttpClient httpClient, bool diposeHttpClient = true)
        {
            _httpClient = httpClient;
            _disposeHttpClient = diposeHttpClient;
        }

        public void SetTimeOut(TimeSpan timeSpan)
        {
            _httpClient.Timeout = timeSpan;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _httpClient.SendAsync(request);
        }

        public void Dispose()
        {
            if (_disposeHttpClient)
            {
                _httpClient.Dispose();
            }
        }
    }
}