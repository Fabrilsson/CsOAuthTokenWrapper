using CsOAuthTokenWrapper.Data.Resources.Common;

namespace CsOAuthTokenWrapper.Data.Resources
{
    internal sealed class OAuthTokenResource : FormUrlEncodedResource
    {
        internal OAuthTokenResource(object body, string uri) : base(body)
        {
            Uri = uri;
        }
    }
}
