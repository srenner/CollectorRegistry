using System.Runtime;
using CollectorRegistry.Shared.MessageRecords;
using RabbitMQ.Client;

namespace CollectorRegistry.GeocodeTestInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Use this tool to send an address to the queue to be geocoded");
            Console.WriteLine("============================================================");

            Console.Write("ENTRY ID (INTEGER): ");
            string? strEntryID = Console.ReadLine();
            int entryID = 0;
            int.TryParse(strEntryID, out entryID);

            Console.Write("CITY: ");
            string? city = Console.ReadLine();

            Console.Write("STATE: ");
            string? state = Console.ReadLine();

            Console.Write("COUNTRY: ");
            string? country = Console.ReadLine();

            Console.Write("ZIP: ");
            string? postalCode = Console.ReadLine();




            var factory = new ConnectionFactory { HostName = "rabbit01", VirtualHost = "/", UserName = "guest", Password = "guest" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "geocode-input",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var record = new GeocodeInput
            {
                EntryID = entryID,
                City = city,
                Region = state,
                Country = country,
                PostalCode = postalCode
            };


        }
    }
}