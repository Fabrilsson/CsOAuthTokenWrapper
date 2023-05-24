using CsOAuthTokenWrapper.Network;

namespace CsOAuthTokenWrapper.Data.Client
{
    public class AuthNetworkClient : NetworkClient, IAuthNetworkClient
    {
        public AuthNetworkClient(HttpClient httpClient, string uri) : base(httpClient)
        {
            Uri = uri;
        }

        protected override string Uri { get; }
    }
}
