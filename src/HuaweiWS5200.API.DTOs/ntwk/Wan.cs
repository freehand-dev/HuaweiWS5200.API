using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.ntwk
{
    public class Wan
    {
        public bool? Enable { get; set; }
        public string? ConnectionStatus { get; set; }
        public string? PPPTrigger { get; set; }
        public string? APN { get; set; }
        public int? MRU { get; set; }
        public string? ServiceList { get; set; }
        public Linkdata? linkdata { get; set; }
        public string? IPv6Addr { get; set; }
        public bool? IPv6Enable { get; set; }
        public string? ConnectionType { get; set; }
        public bool? DNSOverrideAllowed { get; set; }
        public string? PPPDialIpAddr { get; set; }
        public bool? IPv4Enable { get; set; }
        public string? PPPDialIpMode { get; set; }
        public string? UpBandwidthHistory { get; set; }
        public string? WanType { get; set; }
        public string? DownBandwidthHistory { get; set; }
        public bool? MACColoneEnable { get; set; }
        public string? IPv4Addr { get; set; }
        public string? BandwidthTime { get; set; }
        public string? Username { get; set; }
        public string? IPv6AddrType { get; set; }
        public int? UpBandwidthMax { get; set; }
        public int? DownBandwidthMax { get; set; }
        public int? UpBandwidth { get; set; }
        public string? IPv4AddrType { get; set; }
        public int? IsDefault { get; set; }
        public string? IPv6PrefixList { get; set; }
        public string? PPPoEServiceName { get; set; }
        public string? IPv6DnsServers { get; set; }
        public List<VLANDatum>? VLANData { get; set; }
        public string? IPv6ConnectionStatus { get; set; }
        public string? Password { get; set; }
        public int? DownBandwidth { get; set; }
        public int? IsConfigured { get; set; }
        public int? IPv6AddrPrefixLen { get; set; }
        public string? IPv6AddrSet { get; set; }
        public string? DialNum { get; set; }
        public string? WANDHCPOption60 { get; set; }
        public string? AccessType { get; set; }
        public string? IPv6Gateway { get; set; }
        public string? IPv4Mask { get; set; }
        public string? PPPAuthMode { get; set; }
        public string? IPv4DnsServers { get; set; }
        public string? IPv4Gateway { get; set; }
        public string? ID { get; set; }
        public string? AccessStatus { get; set; }
        public string? Name { get; set; }
        public string? MACColone { get; set; }
        public string? LowerLayer { get; set; }
        public string? Alias { get; set; }
        public int? NATType { get; set; }
        public int? PPPIdletime { get; set; }
        public int? MTU { get; set; }
        public int? MSS { get; set; }
    }

    public class VLANDatum
    {
        public int? VLAN1p { get; set; }
        public string? ID { get; set; }
        public int? VLANId { get; set; }
        public string? VLANMode { get; set; }
    }

    public class Linkdata
    {
        public bool? VLANEnable { get; set; }
        public string? ID { get; set; }
        public int? VLAN1p { get; set; }
        public int? VLANId { get; set; }
        public string? VLANMode { get; set; }
    }
}
