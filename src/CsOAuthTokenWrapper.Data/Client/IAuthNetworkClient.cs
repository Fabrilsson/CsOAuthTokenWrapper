using CsOAuthTokenWrapper.Network.Resource;

namespace CsOAuthTokenWrapper.Data.Client
{
    public interface IAuthNetworkClient
    {
        Task<T> RemoteCallAsync<T>(IResource resource) where T : class;
    }
}
