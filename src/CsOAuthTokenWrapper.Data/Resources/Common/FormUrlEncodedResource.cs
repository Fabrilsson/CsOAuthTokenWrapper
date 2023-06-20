using CsOAuthTokenWrapper.Network.Resource;

namespace CsOAuthTokenWrapper.Data.Resources.Common
{
    internal class FormUrlEncodedResource : IResource
    {
        public string? Uri { get; set; }

        public HttpMethod Method => HttpMethod.Post;

        public Dictionary<string, object>? Parameters { get; }

        public string? ContentType { get; }

        public HttpContent Content { get; }

        internal FormUrlEncodedResource(object body)
        {
            var formUrlEncodedKeyValue = new List<KeyValuePair<string, string>>();

            var type = body.GetType();

            foreach (var item in type.GetProperties())
                formUrlEncodedKeyValue.Add(new KeyValuePair<string, string>(item.Name, item?.GetValue(body, null)?.ToString()));

            Content = new FormUrlEncodedContent(formUrlEncodedKeyValue);
        }
    }
}
