using CsOAuthTokenWrapper.Data.Serializer;
using CsOAuthTokenWrapper.Network.Resource;
using System.Text;

namespace CsOAuthTokenWrapper.Data.Resources.Common
{
    internal class JsonResource : IResource, IDisposable
    {
        public string Uri { get; set; }

        public HttpMethod Method => HttpMethod.Post;

        public Dictionary<string, object> Parameters { get; }

        public string ContentType { get; }

        public HttpContent Content { get; }

        public JsonResource(IJsonSerializer jsonSerializer, object body)
        {
            Content = new StringContent(jsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        }

        public void Dispose()
            => Content?.Dispose();
    }
}
