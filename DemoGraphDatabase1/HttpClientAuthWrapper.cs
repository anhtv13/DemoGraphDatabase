using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DemoGraphDatabase1
{
    public class HttpClientAuthWrapper : IHttpClient
    {
        private readonly AuthenticationHeaderValue _authenticationHeader;
        private readonly HttpClient _client;

        public HttpClientAuthWrapper(string username, string password)
        {
            _client = new HttpClient();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return;

            var encoded = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password));
            _authenticationHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(encoded));
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            if (_authenticationHeader != null)
                request.Headers.Authorization = _authenticationHeader;
            return _client.SendAsync(request);
        }
    }
}
