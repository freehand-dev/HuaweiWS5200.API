using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.ntwk
{
    public class GuestNetwork
    {
        public bool? Enable { get; set; }
        public bool? EnableFrequency { get; set; }
        public string? FrequencyBand { get; set; }
        public string? WpaPreSharedKey { get; set; }
        public string? RestTime { get; set; }
        public string? SecOpt { get; set; }
        public string? ID { get; set; }
        public int? PwdScore { get; set; }
        public int? ValidTime { get; set; }
        public bool? CanEnableFrequency { get; set; }
        public string? WifiSsid { get; set; }
    }
}
