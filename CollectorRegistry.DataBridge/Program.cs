using CollectorRegistry.Shared.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using System.Net.NetworkInformation;
using System.Text;

namespace CollectorRegistry.DataBridge
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Ping("web01");
            
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress("https://web01:5001", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Geocode.GeocodeClient(channel);
            /*
              int32 entry_id = 1;
              double geo_lat = 2;
              double geo_long = 3;
              string geo_descr = 4;
            */
            var reply = client.UpdateEntry(
                              new GeocodeUpdateRequest { EntryId = 1, GeoDescr = "Test", GeoLat = 12.34, GeoLong = 56.78 });
            Console.WriteLine("Greeting: " + reply.Message);
            
            var rudeClient = new RudeGreeter.RudeGreeterClient(channel);
            var rudeReply = await rudeClient.BeRudeAsync(new RudeRequest { Name = "Programmer" });
            Console.WriteLine("Rude Greeting: " + rudeReply.Message);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private static void Ping(string hostname)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(hostname, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                Console.WriteLine("Ping Complete");
                Console.WriteLine("---");
            }
        }
    }
}