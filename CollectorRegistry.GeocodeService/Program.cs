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
            Console.WriteLine("CollectorRegistry.GeocodeService is starting up at " + DateTime.UtcNow.ToLongTimeString() + " UTC");

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

            Console.WriteLine("Shutting down at " + DateTime.UtcNow.ToLongTimeString() + " UTC");
        }
    }

    internal sealed class ConsoleHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IOptions<GeocodeSettings> _settings;

        public ConsoleHostedService(
            ILogger<ConsoleHostedService> logger,
            IHostApplicationLifetime appLifetime,
            IOptions<GeocodeSettings> settings)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _settings = settings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        Console.WriteLine("Using API @ " + _settings.Value.BaseURL);
                        while (true)
                        {
                            Console.WriteLine(DateTime.UtcNow.ToLongTimeString());
                            await Task.Delay(1000);
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception");
                    }
                    finally
                    {
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}