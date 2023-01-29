using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessageBrokerTestWorker
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("MessageBrokerTestWorker is starting up at " + DateTime.Now.ToLongTimeString());
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<ConsoleHostedService>();
                    services.AddHostedService<Worker>();
                    services.AddOptions();
                })
                .RunConsoleAsync();
            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}