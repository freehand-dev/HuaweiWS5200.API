using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.ntwk
{
    public class WanDetect
    {
        public string? WanResult { get; set; }
        public string? ConnectionStatus { get; set; }
        public string? DNSServers { get; set; }
        public string? AutoFlag { get; set; }
        public string? ErrReason { get; set; }
        public int? HttpStatus { get; set; }
        public int? AccessPortCount { get; set; }
        public string? ExternalIPAddress { get; set; }
        public int? IPv6PrefixLength { get; set; }
        public int? BackupStatus { get; set; }
        public bool? IPv6Enable { get; set; }
        public string? IPv6DefaultGateway { get; set; }
        public string? AccessType { get; set; }
        public string? IPv6DNSServers { get; set; }
        public string? ConnectionType { get; set; }
        public string? IPv6PrefixList { get; set; }
        public string? PVCResult { get; set; }
        public bool? IPv4Enable { get; set; }
        public string? SearchingStatus { get; set; }
        public string? AccessStatus { get; set; }
        public string? DetailErr { get; set; }
        public string? IPv6ConnectionStatus { get; set; }
        public string? DefaultGateway { get; set; }
        public string? ID { get; set; }
        public string? IPv6Address { get; set; }
        public string? IPv6AddressingType { get; set; }
        public string? Status { get; set; }
        public int? Uptime { get; set; }
    }
}
