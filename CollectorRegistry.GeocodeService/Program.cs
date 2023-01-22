using Microsoft.Extensions.Hosting;

namespace CollectorRegistry.GeocodeService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("CollectorRegistry.GeocodeService is starting up");

            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // 
                });
    }
}