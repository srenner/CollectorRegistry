using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.TestConsole
{
    public class RabbitMQSettings : IOptions<RabbitMQSettings>
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string HeartbeatQueue { get; set; }
        public string GeocodeQueue { get; set; }
        public string ImageQueue { get; set; }

        public RabbitMQSettings Value => throw new NotImplementedException();
    }
}
