using CsOAuthTokenWrapper.Data.Resources.Common;
using CsOAuthTokenWrapper.Data.Serializer;

namespace CsOAuthTokenWrapper.Data.Resources
{
    internal class OAuthTokenResource : JsonResource
    {
        public OAuthTokenResource(IJsonSerializer jsonSerializer, object body) : base(jsonSerializer, body)
        {
            Uri = "oauth2/token";
        }
    }
}
