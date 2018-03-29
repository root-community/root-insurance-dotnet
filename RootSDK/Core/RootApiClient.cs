using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RootSDK.Core
{
    internal class RootApiClient : IRootApiClient
    {
        private readonly ILogger<RootApiClient> _logger;
        private readonly HttpClient _connection;
        private string _apiArea;

        public RootApiClient(IRootConnection connection, ILogger<RootApiClient> logger)
        {
            _logger = logger;
            _connection = connection.Connect();
        }

        public async Task<T> PostAsync<T>(string url, object data, string apiArea = null)
        {
            var content = SerializeData<T>(data);

            var requestUri = RequestUri(url, apiArea);
            var response = await _connection.PostAsync(requestUri, content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();

            LogRequest(response);
            return default(T);
        }

        public async Task<T> GetAsync<T>(string url, string apiArea = null)
        {
            var requestUri = RequestUri(url, apiArea);
            var response = await _connection.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();

            LogRequest(response);
            return default(T);
        }

        public async Task<T> PutAsync<T>(string url, object data, string apiArea = null)
        {
            var content = SerializeData<T>(data);

            var requestUri = RequestUri(url, apiArea);
            var response = await _connection.PutAsync(requestUri, content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>();

            LogRequest(response);
            return default(T);
        }

        private void LogRequest(HttpResponseMessage response)
        {
            var responseUri = response.RequestMessage.RequestUri.ToString();
            _logger.LogInformation(
                $"Resource server returned an error. StatusCode: {response.StatusCode}, Uri {responseUri}");
        }

        public void SetApiArea(string area)
        {
            _apiArea = area;
        }

        private static StringContent SerializeData<T>(object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data),
                Encoding.UTF8, "application/json");
            return content;
        }

        /// <summary>
        /// This allows a dev to either specify the area part of a url ad hoc or at instance level
        /// </summary>
        /// <param name="url"></param>
        /// <param name="apiArea"></param>
        /// <returns></returns>
        private string RequestUri(string url, string apiArea = null)
        {
            // https://stackoverflow.com/a/23438417/1105314
            // no leading slashes here
            return $"{_apiArea ?? apiArea}/{url}";
        }
    }
}