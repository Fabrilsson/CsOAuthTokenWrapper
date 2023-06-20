using CsOAuthTokenWrapper.Network.Resource;
using CsOAuthTokenWrapper.Network.Wrappers;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CsOAuthTokenWrapper.Network
{
    public abstract class NetworkClient
    {
        private readonly HttpClient _httpClient;

        protected abstract string Uri { get; }

        public NetworkClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> RemoteCallAsync<T>(IResource resource) where T : class
        {
            var retryTimeout = HttpPolicyWrapper.GetAsyncPolicy();

            HttpRequestMessage request;

            if (resource.Method != HttpMethod.Post)
                throw new NotImplementedException();
            
            request = GetPostRequest(resource);

            var response = await retryTimeout.ExecuteAsync(() => _httpClient.SendAsync(request)).ConfigureAwait(false);

            var result = response;

            if (result != null && (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created))
            {
                var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(content);
            }

            if (result is null || result.Content is null)
                throw new Exception($"Either response or response content was null. Request Uri {resource.Uri}");
            else
                throw new Exception($"StatusCode returned by Uri: {resource.Uri} was {result.StatusCode}");
        }

        private static HttpRequestMessage GetPostRequest(IResource resource)
        {
            var requestUri = new Uri(resource.Uri);

            var request = new HttpRequestMessage(resource.Method, requestUri)
            {
                Content = resource.Content
            };

            return request;
        }
    }
}