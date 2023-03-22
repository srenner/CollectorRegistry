using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.ImageService.Settings
{
    public class RabbitMQSettings : IOptions<RabbitMQSettings>
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageInputQueue { get; set; }
        public string ImageOutputQueue { get; set; }

        public RabbitMQSettings Value => throw new NotImplementedException();
    }
}
