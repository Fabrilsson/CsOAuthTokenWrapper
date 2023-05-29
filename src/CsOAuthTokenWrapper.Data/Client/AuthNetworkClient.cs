using CsOAuthTokenWrapper.Network;

namespace CsOAuthTokenWrapper.Data.Client
{
    internal sealed class AuthNetworkClient : NetworkClient, IAuthNetworkClient
    {
        public AuthNetworkClient(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string Uri { get; }
    }
}
