using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HuaweiWS5200.API.DTOs.system
{
    public class UserLoginProof : Csrf
    {
        [JsonPropertyName("err")]
        public int? Err { get; set; }

        [JsonPropertyName("ishilink")]
        public int? Ishilink { get; set; }

        [JsonPropertyName("errorCategory")]
        public string? ErrorCategory { get; set; }

        [JsonPropertyName("count")]
        public int? Count { get; set; }

        [JsonPropertyName("maxfailtimes")]
        public int? Maxfailtimes { get; set; }

        [JsonPropertyName("level")]
        public int? level { get; set; }

        [JsonPropertyName("rsapubkeysignature")]
        public string? rsapubkeysignature { get; set; }

        [JsonPropertyName("rsae")]
        public string? rsae { get; set; }

        [JsonPropertyName("rsan")]
        public string? rsan { get; set; }

        [JsonPropertyName("serversignature")]
        public string? serversignature { get; set; }
    }
}