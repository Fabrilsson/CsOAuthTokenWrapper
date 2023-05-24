namespace CsOAuthTokenWrapper.Data.Serializer
{
    public interface IJsonSerializer
    {
        T? Deserialize<T>(string item);
        string? Serialize(object item);
    }
}
