using Microsoft.Extensions.Hosting;
using CollectorRegistry.Shared.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Text;

namespace CollectorRegistry.ImageService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ImageService starting at " + DateTime.Now.ToLongTimeString());

            await Host.CreateDefaultBuilder(args)
                 .ConfigureServices((hostContext, services) =>
                 {
                     var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                     var config = builder.Build();
                     //services.Configure<ConnectionSettings>(config.GetSection("ConnectionSettings"));
                     services.AddHostedService<ImageService>();
                     services.AddOptions();
                 })
                 .RunConsoleAsync();

            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}