using CollectorRegistry.Shared.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.NetworkInformation;
using System.Text;

namespace CollectorRegistry.DataBridge
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("DataBridge starting at " + DateTime.Now.ToLongTimeString());

            await Host.CreateDefaultBuilder(args)
                 .ConfigureServices((hostContext, services) =>
                 {
                     var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                     var config = builder.Build();
                     services.Configure<ConnectionSettings>(config.GetSection("ConnectionSettings"));
                     services.AddHostedService<DataBridgeService>();
                     services.AddOptions();
                 })
                 .RunConsoleAsync();

            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }

        private static PingReply Ping(string hostname)
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