using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.ntwk
{
    public class GuestNetworkRequest
    {
        [JsonPropertyName("config5g")]
        public GuestNetwork? Config5G { get; set; }

        [JsonPropertyName("config2g")]
        public GuestNetwork? Config2G { get; set; }
    }
}
