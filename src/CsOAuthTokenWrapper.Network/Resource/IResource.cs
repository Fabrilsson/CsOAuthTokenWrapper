namespace CsOAuthTokenWrapper.Network.Resource
{
    public interface IResource
    {
        string Uri { get; }
        HttpMethod Method { get; }
        Dictionary<string, object> Parameters { get; }
        string ContentType { get; }
        HttpContent Content { get; }
    }
}
