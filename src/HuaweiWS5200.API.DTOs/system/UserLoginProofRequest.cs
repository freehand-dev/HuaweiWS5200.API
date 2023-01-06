using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.system
{
    public class UserLoginProofRequest
    {
        [JsonPropertyName("clientproof")]
        public string? ClientProof { get; set; }

        [JsonPropertyName("finalnonce")]
        public string? FinalNonce { get; set; }

    }
}
