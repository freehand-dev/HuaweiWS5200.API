using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs
{
    public class RequestData<T>
    {
        [JsonPropertyName("csrf")]
        public Csrf? Csrf { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        public RequestData()
        {

        }

        public RequestData(string csrfParam, string csrfToken)
        {
            this.Csrf = new Csrf()
            {
                CsrfParam = csrfParam,
                CsrfToken = csrfToken
            };
        }

        public RequestData(string csrfParam, string csrfToken, T Data)
        {
            this.Data = Data;
            this.Csrf = new Csrf()
            {
                CsrfParam = csrfParam,
                CsrfToken = csrfToken
            };
        }
    }
}
