using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CollectorRegistry.MessageBroker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddMassTransit(x =>
                {

                    // TODO rabbitmq config and devops path
                    /*
                    
                    scripts todo:
                    - create docker network ("registry-net")
                    - create rabbitmq "registry-rabbit" container with a hostname "rabbit01" and use our created network
                    - .net docker config for .net clients to use our created network


                     */ 

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("rabbit01", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        cfg.ConfigureEndpoints(context);
                    });
                });
            })
            .Build()
            .RunAsync();

            Console.WriteLine("Starting Message Broker");
        }
    }
}
