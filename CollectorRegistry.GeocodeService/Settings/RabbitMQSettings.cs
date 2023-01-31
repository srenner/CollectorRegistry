using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.GeocodeService.Settings
{
    public class RabbitMQSettings : IOptions<RabbitMQSettings>
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GeocodeInputQueue { get; set; }
        public string GeocodeOutputQueue { get; set; }
        public string ImageQueue { get; set; }

        public RabbitMQSettings Value => throw new NotImplementedException();
    }
}
