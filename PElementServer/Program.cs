using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PElementServer.Thrift;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using Thrift.Transport.Server;

namespace PElementServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.AddSingleton<IHostedService, PElementHostedService>();
            });

            await builder.RunConsoleAsync();
        }
    }

    public class PElementHostedService : BackgroundService
    {
        private TServer server;

        public PElementHostedService()
        {
            var protoFactory = new TBinaryProtocol.Factory();
            var transFactory = new TBufferedTransport.Factory();
            var handler = new PElementServiceImplementation();
            var processor = new PElementService.AsyncProcessor(handler);

            var transport = new TServerSocketTransport(5550, new TConfiguration());
            server = new TThreadPoolAsyncServer(processor, transport, transFactory, protoFactory);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            server.ServeAsync(default);
            Console.WriteLine("Thrift Demo server 'Chemical elements' successfully started");
            
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        public override void Dispose()
        {
            server.Stop();
        }
    }
}
