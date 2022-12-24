// See https://aka.ms/new-console-template for more information


using CollectorRegistry.Shared;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "entry-address",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    string message = "Hello World!";


    var testEntry = new EntryAddress
    {
        EntryID = 1,
        City = "St. Louis",
        Region = "MO",
        PostalCode = "63119",
        Country = "USA",
        GeoLat = null,
        GeoLong = null
    };


    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(testEntry));

    channel.BasicPublish(exchange: "",
                         routingKey: "entry-address",
                         basicProperties: null,
                         body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();