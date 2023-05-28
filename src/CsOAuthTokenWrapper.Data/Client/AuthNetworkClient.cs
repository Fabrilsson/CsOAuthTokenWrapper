using CsOAuthTokenWrapper.Network;

namespace CsOAuthTokenWrapper.Data.Client
{
    internal sealed class AuthNetworkClient : NetworkClient, IAuthNetworkClient
    {
        internal AuthNetworkClient(HttpClient httpClient, string uri) : base(httpClient)
        {
            Uri = uri;
        }

        protected override string Uri { get; }
    }
}
