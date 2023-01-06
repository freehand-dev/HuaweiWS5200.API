using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs
{
    public class Csrf
    {
        [JsonPropertyName("csrf_param")]
        public string? CsrfParam { get; set; }

        [JsonPropertyName("csrf_token")]
        public string? CsrfToken { get; set; }
    }
}
