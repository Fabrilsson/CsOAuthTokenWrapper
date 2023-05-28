using CsOAuthTokenWrapper.Data.Resources.Common;
using CsOAuthTokenWrapper.Data.Serializer;

namespace CsOAuthTokenWrapper.Data.Resources
{
    internal sealed class OAuthTokenResource : JsonResource
    {
        internal OAuthTokenResource(IJsonSerializer jsonSerializer, object body, string uri) : base(jsonSerializer, body)
        {
            Uri = uri;
        }
    }
}
