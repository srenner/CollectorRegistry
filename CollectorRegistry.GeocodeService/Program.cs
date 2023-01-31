using CollectorRegistry.GeocodeService.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

// hosting setup inspired by https://dfederm.com/building-a-console-app-with-.net-generic-host/

namespace CollectorRegistry.GeocodeService
{
    internal sealed class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("CollectorRegistry.GeocodeService is starting up at " + DateTime.Now.ToLongTimeString());

            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                    var config = builder.Build();
                    services.Configure<GeocodeSettings>(config.GetSection("GeocodeSettings"));
                    services.AddHostedService<ConsoleHostedService>();
                    services.AddOptions();
                })
                .RunConsoleAsync();
            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}