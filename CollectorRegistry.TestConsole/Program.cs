using MassTransit;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CollectorRegistry.TestConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("CollectorRegistry.TestConsole is starting up at " + DateTime.Now.ToLongTimeString());

            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                    var config = builder.Build();
                    //services.Configure<GeocodeSettings>(config.GetSection("GeocodeSettings"));
                    services.AddHostedService<ConsoleHostedService>();
                    services.AddOptions();
                })
                .RunConsoleAsync();
            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}