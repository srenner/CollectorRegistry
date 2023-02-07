using CollectorRegistry.Shared.MessageRecords;
using CollectorRegistry.Shared.Protos;
using Grpc.Net.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorRegistry.DataBridge
{
    internal class DataBridgeService : IHostedService
    {
        private readonly ILogger<DataBridgeService> _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IOptions<ConnectionSettings> _settings;

        private IModel _channel;
        private IConnection _connection;
        private EventingBasicConsumer _consumer;

        public DataBridgeService(ILogger<DataBridgeService> logger, IHostApplicationLifetime appLifetime, IOptions<ConnectionSettings> settings)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _settings = settings;


            var factory = new ConnectionFactory
            {
                HostName = _settings.Value.RabbitMQHostName,
                VirtualHost = _settings.Value.RabbitMQVirtualHost,
                UserName = _settings.Value.RabbitMQUsername,
                Password = _settings.Value.RabbitMQPassword,
                ClientProvidedName = "DataBridge"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += Consumer_Received;


        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run( () =>
                {
                    try
                    {
                        _logger.LogDebug("StartAsync");
                        AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                        
                        string[] queues = { _settings.Value.RabbitMQGeocodeQueue, "test-queue" };
                        
                        DeclareQueues(queues);



                        while (!cancellationToken.IsCancellationRequested)
                        {
                            Task.Delay(-1);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception: " + ex.Message);
                    }
                    finally
                    {
                        _logger.LogDebug("Stopping DataBridge");
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;



        private void OnStopping()
        {
            // ...
        }

        private void OnStopped()
        {
            // ...
        }


        private void DeclareQueues(string[] queues)
        {

            if(_channel.IsOpen)
            {
                foreach(string queue in queues)
                {
                    _channel.QueueDeclare(queue: queue,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                    _channel.BasicConsume(queue, false, _consumer);
                }


                
            }
            else
            {
                _logger.LogDebug("Cannot declare queues on closed channel");
            }


        }

        protected void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            string queue = e.RoutingKey;
            bool isProcessed = false;
            _logger.LogDebug("Received from queue: " + queue);
            if (queue == _settings.Value.RabbitMQGeocodeQueue)
            {

                isProcessed = true;
            }
            else
            {
                _logger.LogDebug("Unknown queue: " + queue);
            }


            var body = e.Body.ToArray();
            // copy or deserialise the payload
            // and process the message
            // ...

            if (isProcessed)
            {
                _channel.BasicAck(e.DeliveryTag, false);
            }
        }

        private void UnaryGeocodeUpdate()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress(_settings.Value.gRPCAddress, new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Geocode.GeocodeClient(channel);
            var reply = client.UpdateEntry(
                              new GeocodeUpdateRequest { EntryId = 1, GeoDescr = "Test", GeoLat = 12.34, GeoLong = 56.78 });
            Console.WriteLine("Test: " + reply.Message);

            throw new NotImplementedException();
        }


    }
}
