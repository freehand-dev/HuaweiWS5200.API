using System.Text.Json.Serialization;

namespace HuaweiWS5200.API.DTOs.system
{
    public class Custinfo
    {
        public string? CustDeviceName { get; set; }
        public string? CustDeviceType { get; set; }
        public string? CustENFriendlyName { get; set; }
        public int? CustDeviceBand { get; set; }
        public string? CustZHFriendlyName { get; set; }
    }

    public class Devcap
    {
        public int? GuestNetwork { get; set; }
        public HardwareCapability? HardwareCapability { get; set; }
        public string? Vendor { get; set; }
        public string? Version { get; set; }
        public SoftwareCapability? SoftwareCapability { get; set; }
        public int? WIFI { get; set; }
        public int? RebootTime { get; set; }
        public int? USB { get; set; }
        public string? WifiAreaCode { get; set; }
        public int? Area { get; set; }
        public bool? SupportAPP { get; set; }
        public int? PowerSave { get; set; }
    }

    public class HardwareCapability
    {
        [JsonPropertyName("4")]
        public int? _4 { get; set; }

        [JsonPropertyName("8")]
        public int? _8 { get; set; }

        [JsonPropertyName("1")]
        public int? _1 { get; set; }

        [JsonPropertyName("5")]
        public int? _5 { get; set; }

        [JsonPropertyName("9")]
        public int? _9 { get; set; }

        [JsonPropertyName("6")]
        public int? _6 { get; set; }

        [JsonPropertyName("11")]
        public int? _11 { get; set; }

        [JsonPropertyName("3")]
        public int? _3 { get; set; }

        [JsonPropertyName("7")]
        public int? _7 { get; set; }

        [JsonPropertyName("2")]
        public int? _2 { get; set; }

        [JsonPropertyName("10")]
        public int? _10 { get; set; }

        [JsonPropertyName("0")]
        public int? _0 { get; set; }
    }

    public class Modcap
    {
        public int? isSupportRepeaterConfig { get; set; }
        public int? isSupportWlanTimeSwitchEnhance { get; set; }
        public int? isSupportFreeControl { get; set; }
        public int? isSupportHilinkMess { get; set; }
        public int? isSupportDiagnose2G { get; set; }
        public int? isSupportMaxHisRate { get; set; }
        public int? isSupportNextTimeUp { get; set; }
        public int? support_telecom_pd { get; set; }
        public int? isSupportQueryAndSetChannel { get; set; }
        public int? support_macflt { get; set; }
        public int? isSupportQosNewConfig { get; set; }
        public int? isSupportNewDeviceAdd { get; set; }
        public int? isSupportDelMpsDevice { get; set; }
        public int? support_html_custom_app { get; set; }
        public int? isSupportWifiDbho { get; set; }
        public int? support_andlink_v2 { get; set; }
        public int? support_xlink_sn { get; set; }
        public int? isSupportDiagnose5G { get; set; }
        public int? isSupportNFC { get; set; }
        public int? support_elink { get; set; }
        public int? support_cloud_mac_filter { get; set; }
        public int? support_login { get; set; }
        public int? support_testwifiencrypt { get; set; }
        public int? support_andlink { get; set; }
        public int? isSupportHilinkCap { get; set; }
        public int? isSupportRepeater { get; set; }
        public int? isNotSupportGuest5G { get; set; }
        public int? support_guide_start_login { get; set; }
        public int? isSupportSubMaskConfig { get; set; }
        public int? isSupportPowerKey { get; set; }
        public int? isSupportBackhaul { get; set; }
        public int? isSupportEthBrdgConfig { get; set; }
        public int? isSupportGuestExtendRestTime { get; set; }
        public int? isSupportNtwkCapCompare { get; set; }
        public int? support_urlflt { get; set; }
        public int? support_power_in_wifi_guide { get; set; }
        public int? isSupportHissidOpt { get; set; }
        public int? support_iptv { get; set; }
        public int? isSupportZhSSID { get; set; }
        public int? support_test_guide { get; set; }
        public int? isSupportWlanFilterEnhance { get; set; }
        public int? support_zjct_custom { get; set; }
        public int? isSupportHybrid { get; set; }
        public int? support_ipv6_enable { get; set; }
        public int? support_guide_ssid { get; set; }
        public int? support_wolink { get; set; }
        public int? isSupportGuideOptimize { get; set; }
        public int? support_wlan_instance_custom { get; set; }
        public int? support_router_custom { get; set; }
    }

    public class Other
    {
        public bool? IsNeedSalt { get; set; }
        public bool? guide { get; set; }
        public int? FirstLogin { get; set; }
    }

    public class DeviceInfo
    {
        public string? SerialNumber { get; set; }
        public string? RouterType { get; set; }
        public int? UpTime { get; set; }
        public string? uuid { get; set; }
        public string? ManufacturerOUI { get; set; }
        public string? EmuiVersion { get; set; }
        public Custinfo? custinfo { get; set; }
        public int? UpgradeTime { get; set; }
        public string? ManufacturerId { get; set; }
        public Modcap? modcap { get; set; }
        public int? SkuType { get; set; }
        public Other? other { get; set; }
        public SmartDevInfo? SmartDevInfo { get; set; }
        public int? NtwkCapScore { get; set; }
        public int? MacFilterCapacity { get; set; }
        public Devcap? devcap { get; set; }
        public string? DeviceIconType { get; set; }
        public int? SNHashType { get; set; }
        public string? HardwareVersion { get; set; }
        public string? SoftwareVersion { get; set; }
        public string? DeviceName { get; set; }
        public string? FriendlyName { get; set; }
        public string? csrf_param { get; set; }
        public string? csrf_token { get; set; }
    }

    public class SmartDevInfo
    {
        public string? prodId { get; set; }
    }

    public class SoftwareCapability
    {
        [JsonPropertyName("4")]
        public int? _4 { get; set; }

        [JsonPropertyName("31")]
        public int? _31 { get; set; }

        [JsonPropertyName("5")]
        public int? _5 { get; set; }

        [JsonPropertyName("80")]
        public int? _80 { get; set; }

        [JsonPropertyName("50")]
        public int? _50 { get; set; }

        [JsonPropertyName("32")]
        public int? _32 { get; set; }

        [JsonPropertyName("11")]
        public int? _11 { get; set; }

        [JsonPropertyName("12")]
        public int? _12 { get; set; }

        [JsonPropertyName("90")]
        public int? _90 { get; set; }

        [JsonPropertyName("7")]
        public int? _7 { get; set; }

        [JsonPropertyName("51")]
        public int? _51 { get; set; }

        [JsonPropertyName("74")]
        public int? _74 { get; set; }

        [JsonPropertyName("44")]
        public int? _44 { get; set; }

        [JsonPropertyName("14")]
        public int? _14 { get; set; }

        [JsonPropertyName("91")]
        public int? _91 { get; set; }

        [JsonPropertyName("34")]
        public int? _34 { get; set; }

        [JsonPropertyName("45")]
        public int? _45 { get; set; }

        [JsonPropertyName("75")]
        public int? _75 { get; set; }

        [JsonPropertyName("9")]
        public int? _9 { get; set; }

        [JsonPropertyName("6")]
        public int? _6 { get; set; }

        [JsonPropertyName("16")]
        public int? _16 { get; set; }

        [JsonPropertyName("66")]
        public int? _66 { get; set; }

        [JsonPropertyName("76")]
        public int? _76 { get; set; }

        [JsonPropertyName("67")]
        public int? _67 { get; set; }

        [JsonPropertyName("17")]
        public int? _17 { get; set; }

        [JsonPropertyName("36")]
        public int? _36 { get; set; }

        [JsonPropertyName("95")]
        public int? _95 { get; set; }

        [JsonPropertyName("27")]
        public int? _27 { get; set; }

        [JsonPropertyName("88")]
        public int? _88 { get; set; }

        [JsonPropertyName("58")]
        public int? _58 { get; set; }

        [JsonPropertyName("55")]
        public int? _55 { get; set; }

        [JsonPropertyName("56")]
        public int? _56 { get; set; }

        [JsonPropertyName("97")]
        public int? _97 { get; set; }

        [JsonPropertyName("98")]
        public int? _98 { get; set; }

        [JsonPropertyName("86")]
        public int? _86 { get; set; }

        [JsonPropertyName("38")]
        public int? _38 { get; set; }

        [JsonPropertyName("57")]
        public int? _57 { get; set; }

        [JsonPropertyName("87")]
        public int? _87 { get; set; }

        [JsonPropertyName("28")]
        public int? _28 { get; set; }

        [JsonPropertyName("78")]
        public int? _78 { get; set; }

        [JsonPropertyName("48")]
        public int? _48 { get; set; }

        [JsonPropertyName("39")]
        public int? _39 { get; set; }

        [JsonPropertyName("106")]
        public int? _106 { get; set; }

        [JsonPropertyName("49")]
        public int? _49 { get; set; }

        [JsonPropertyName("79")]
        public int? _79 { get; set; }

        [JsonPropertyName("69")]
        public int? _69 { get; set; }

        [JsonPropertyName("19")]
        public int? _19 { get; set; }

        [JsonPropertyName("105")]
        public int? _105 { get; set; }

        [JsonPropertyName("47")]
        public int? _47 { get; set; }

        [JsonPropertyName("113")]
        public int? _113 { get; set; }

        [JsonPropertyName("81")]
        public int? _81 { get; set; }

        [JsonPropertyName("77")]
        public int? _77 { get; set; }

        [JsonPropertyName("65")]
        public int? _65 { get; set; }

        [JsonPropertyName("54")]
        public int? _54 { get; set; }

        [JsonPropertyName("72")]
        public int? _72 { get; set; }

        [JsonPropertyName("59")]
        public int? _59 { get; set; }

        [JsonPropertyName("37")]
        public int? _37 { get; set; }

        [JsonPropertyName("41")]
        public int? _41 { get; set; }

        [JsonPropertyName("25")]
        public int? _25 { get; set; }

        [JsonPropertyName("24")]
        public int? _24 { get; set; }

        [JsonPropertyName("21")]
        public int? _21 { get; set; }

        [JsonPropertyName("18")]
        public int? _18 { get; set; }

        [JsonPropertyName("13")]
        public int? _13 { get; set; }

        [JsonPropertyName("10")]
        public int? _10 { get; set; }

        [JsonPropertyName("2")]
        public int? _2 { get; set; }

        [JsonPropertyName("109")]
        public int? _109 { get; set; }

        [JsonPropertyName("8")]
        public int? _8 { get; set; }

        [JsonPropertyName("33")]
        public int? _33 { get; set; }

        [JsonPropertyName("64")]
        public int? _64 { get; set; }

        [JsonPropertyName("26")]
        public int? _26 { get; set; }

        [JsonPropertyName("102")]
        public int? _102 { get; set; }

        [JsonPropertyName("29")]
        public int? _29 { get; set; }

        [JsonPropertyName("52")]
        public int? _52 { get; set; }

        [JsonPropertyName("0")]
        public int? _0 { get; set; }

        [JsonPropertyName("15")]
        public int? _15 { get; set; }

        [JsonPropertyName("23")]
        public int? _23 { get; set; }

        [JsonPropertyName("1")]
        public int? _1 { get; set; }

        [JsonPropertyName("71")]
        public int? _71 { get; set; }

        [JsonPropertyName("73")]
        public int? _73 { get; set; }

        [JsonPropertyName("83")]
        public int? _83 { get; set; }

        [JsonPropertyName("99")]
        public int? _99 { get; set; }

        [JsonPropertyName("107")]
        public int? _107 { get; set; }

        [JsonPropertyName("68")]
        public int? _68 { get; set; }

        [JsonPropertyName("110")]
        public int? _110 { get; set; }

        [JsonPropertyName("3")]
        public int? _3 { get; set; }

        [JsonPropertyName("82")]
        public int? _82 { get; set; }

        [JsonPropertyName("30")]
        public int? _30 { get; set; }

        [JsonPropertyName("61")]
        public int? _61 { get; set; }

        [JsonPropertyName("42")]
        public int? _42 { get; set; }

        [JsonPropertyName("20")]
        public int? _20 { get; set; }
    }
}
