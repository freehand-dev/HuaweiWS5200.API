using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaweiWS5200.API.DTOs.system
{
    public class HostInfo
    {
        public string? ID { get; set; }
        public string? MACAddress { get; set; }
        public bool? IsSetupSlave { get; set; }
        public bool? HiLinkDevice { get; set; }
        public int? IsSupportNoManage { get; set; }
        public bool? HiLinkDevHide { get; set; }
        public string? IPAddress { get; set; }
        public bool? Active { get; set; }
        public bool? Active46 { get; set; }
        public bool? WlanActive { get; set; }
        public bool? IsSlave { get; set; }
        public int? ShowDeviceRealRate { get; set; }
        public int? UpRate { get; set; }
        public int? DownRate { get; set; }
        public string? AccessRecord { get; set; }
        public string? TxKBytes { get; set; }
        public string? RxKBytes { get; set; }
        public string? IPv6Address { get; set; }
        public bool? V6Active { get; set; }
        public string? IconType { get; set; }
        public string? ActualName { get; set; }
        public string? domain { get; set; }
        public string? HostName { get; set; }
        public string? interfaceType { get; set; }
        public string? Layer2interface { get; set; }
        public string? AddressSource { get; set; }
        public string? LeaseTime { get; set; }
        public string? VendorClassID { get; set; }
        public bool? hwtypeoptionnew { get; set; }
        public string? Frequency { get; set; }
        public bool? IsGuest { get; set; }
        public string? MacFilterID { get; set; }
        public bool? ParentControlEnable { get; set; }
        public bool? ParentControl { get; set; }
        public bool? DeviceDownRateEnable { get; set; }
        public string? QosclassID { get; set; }
        public string? PolicerID { get; set; }
        public int? ClassQueue { get; set; }
        public string? ActualManu { get; set; }
        public string? ActualType { get; set; }
        public string? ProdId { get; set; }
        public int? Feature { get; set; }
        public int? DeviceMaxUpLoadRate { get; set; }
        public int? DeviceMaxDownLoadRate { get; set; }
    }
}
