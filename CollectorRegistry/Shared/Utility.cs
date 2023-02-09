using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.Shared
{
    public static class Utility
    {
        [UnsupportedOSPlatform("browser")]
        public static PingReply Ping(string hostname)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            return pingSender.Send(hostname, timeout, buffer, options);
        }
    }
}
