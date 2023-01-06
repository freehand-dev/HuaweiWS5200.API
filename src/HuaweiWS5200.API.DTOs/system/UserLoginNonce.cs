using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HuaweiWS5200.API.DTOs.system
{
    public class UserLoginNonce: Csrf
    {
        [JsonPropertyName("salt")]
        public string? Salt { get; set; }

        [JsonPropertyName("err")]
        public int? Err { get; set; }

        [JsonPropertyName("modeselected")]
        public int? ModeSelected { get; set; }

        [JsonPropertyName("servernonce")]
        public string? ServerNonce { get; set; }

        [JsonPropertyName("isopen")]
        public int? IsOpen { get; set; }

        [JsonPropertyName("iterations")]
        public int? Iterations { get; set; }
    }
}
