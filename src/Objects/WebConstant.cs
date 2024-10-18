using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IP_Address_Lookup.src.Objects
{
    internal class WebConstant
    {
        public static readonly string PROXY_CHECK_V2_API = "https://proxycheck.io/v2/{0}?vpn=1&asn=1";
        public static readonly string IPIFY_API = "https://api.ipify.org/";
    }
}
