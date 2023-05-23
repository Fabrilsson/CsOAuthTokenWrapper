namespace CsOAuthTokenWrapper.Data.Serializer
{
    internal interface IJsonSerializer
    {
        T? Deserialize<T>(string item);
        string? Serialize(object item);
    }
}
