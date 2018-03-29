using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RootSDK.Core
{
    internal class RootConnection: IRootConnection
    {
        private readonly ILogger<RootConnection> _logger;
        private readonly RootOptions _options;

        public RootConnection(IOptions<RootOptions> options, ILogger<RootConnection> logger)
        {
            _logger = logger;
            _options = options.Value;
        }

        public HttpClient Connect()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthToken(_options.ApiKey);
            
            // https://stackoverflow.com/a/23438417/1105314
            // You must place a slash at the end of the BaseAddress
            client.BaseAddress = new Uri(_options.ApiUrl);
            return client;
        }

        private static AuthenticationHeaderValue AuthToken(string username = "", string password = "")
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}