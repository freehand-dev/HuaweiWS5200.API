using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaweiWS5200.API.DTOs.ntwk
{
    public class WanDiagnose
    {
        public bool? X_IPv4Enable { get; set; }
        public string? DownMaxBitRate { get; set; }
        public string? StatusCode { get; set; }
        public string? MaxBitRate { get; set; }
        public bool? HasInternetWan { get; set; }
        public string? AutoFlag { get; set; }
        public string? ErrReason { get; set; }
        public string? X_IPv6DefaultGateway { get; set; }
        public string? DuplexMode { get; set; }
        public string? DetailError { get; set; }
        public string? DefaultGateway { get; set; }
        public string? X_IPv6PrefixList { get; set; }
        public string? X_IPv6AddressingType { get; set; }
        public string? UpMaxBitRate { get; set; }
        public string? ExternalIPAddress { get; set; }
        public string? ConnectionType { get; set; }
        public string? X_IPv6ConnectionStatus { get; set; }
        public string? X_IPv6Address { get; set; }
        public string? ConnectionStatus { get; set; }
        public string? Status { get; set; }
        public string? MACAddress { get; set; }
        public bool? X_IPv6Enable { get; set; }
        public int? Uptime { get; set; }
        public string? WanType { get; set; }
        public string? DNSServers { get; set; }
        public int? X_IPv6PrefixLength { get; set; }
        public string? DetailErr { get; set; }
        public string? LinkStatus { get; set; }
        public string? WANAccessType { get; set; }
        public string? ManWanIP { get; set; }
        public string? X_IPv6DNSServers { get; set; }
    }
}
