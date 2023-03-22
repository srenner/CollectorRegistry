using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http.Headers;

namespace CollectorRegistry.TestConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("CollectorRegistry.TestConsole is starting up at " + DateTime.Now.ToLongTimeString());

            var url = "https://nominatim.openstreetmap.org/search.php?city=Shawnee&state=KS&country=USA&postalcode=&format=jsonv2";
            HttpClient httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(".NET", "7.0"));
            var response = await httpClient.SendAsync(request);
            var txt = await response.Content.ReadAsStringAsync();

            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                    var config = builder.Build();
                    services.Configure<RabbitMQSettings>(config.GetSection("RabbitMQ"));
                    
                    //services.AddHostedService<ConsoleHostedService>();
                    services.AddOptions();
                })
                .RunConsoleAsync();
            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}