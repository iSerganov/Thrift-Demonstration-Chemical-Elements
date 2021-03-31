using PElementCore.Thrift;
using System;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport.Client;

namespace PElementClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
           await Go();
        }

        static private async Task Go()
        {
            Console.WriteLine("Welcome to Thrift elementary Demo. We will check the details of Oxygen:");
            var name = "Oxygen";
            TSocketTransport transport = new TSocketTransport("127.0.0.1", 5550, new TConfiguration());
            TProtocol proto = new TBinaryProtocol(transport);
            PElementService.Client client = new PElementService.Client(proto);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            transport.OpenAsync(default);

            PElement result = await client.GetAsync(name);

            Console.WriteLine(result.ToString());
            transport.Close();
            Console.ReadKey();
        }
    }
}
