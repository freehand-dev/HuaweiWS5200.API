using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaweiWS5200.API.DTOs.ntwk
{
    public class GuestNetworkResponse: Csrf
    {
        public int? errcode { get; set; }
        public string? ssid { get; set; }
    }
}
