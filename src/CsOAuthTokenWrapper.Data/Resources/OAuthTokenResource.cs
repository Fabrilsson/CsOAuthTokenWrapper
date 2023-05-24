using CsOAuthTokenWrapper.Data.Resources.Common;
using CsOAuthTokenWrapper.Data.Serializer;

namespace CsOAuthTokenWrapper.Data.Resources
{
    internal class OAuthTokenResource : JsonResource
    {
        public OAuthTokenResource(IJsonSerializer jsonSerializer, object body, string uri) : base(jsonSerializer, body)
        {
            Uri = uri;
        }
    }
}
