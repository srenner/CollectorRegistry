using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.DataBridge
{
    public class ConnectionSettings : IOptions<ConnectionSettings>
    {
        public string gRPCAddress { get; set; }
        public string RabbitMQHostName { get; set; }
        public string RabbitMQVirtualHost { get; set; }
        public string RabbitMQUsername { get; set; }
        public string RabbitMQPassword { get; set; }
        public string RabbitMQGeocodeQueue { get; set; }

        public ConnectionSettings Value => throw new NotImplementedException();
    }
}
