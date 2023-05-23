using Newtonsoft.Json;

namespace CsOAuthTokenWrapper.Data.Serializer
{
    internal class JsonSerializer
    {
        public T Deserialize<T>(string item)
        {
            if (string.IsNullOrEmpty(item))
                return default;

            return JsonConvert.DeserializeObject<T>(item);
        }

        public string Serialize(object item)
        {
            if (item == null)
                return null;

            return JsonConvert.SerializeObject(item);
        }
    }
}
