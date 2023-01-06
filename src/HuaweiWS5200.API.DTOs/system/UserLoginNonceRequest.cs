using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.system
{
    public class UserLoginNonceRequest
    {
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("firstnonce")]
        public string? FirstNonce { get; set; }

        static public string GenrateFirstNonce()
        {
            Random rnd = new Random();
            byte[] b = new byte[32];
            rnd.NextBytes(b);
            return Convert.ToHexString(b).ToLower();
        }
    }
}
