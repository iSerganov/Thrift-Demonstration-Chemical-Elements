using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PElementServer.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport.Client;

namespace PElementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PElementController : ControllerBase
    {
        private readonly ILogger<PElementController> _logger;

        public PElementController(ILogger<PElementController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<PElement> Get(string name)
        {
            TSocketTransport transport = new TSocketTransport("server", 5550, new TConfiguration());
            TProtocol proto = new TBinaryProtocol(transport);
            PElementService.Client client = new PElementService.Client(proto);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            transport.OpenAsync(default);

            PElement result = await client.GetAsync(name);

            transport.Close();
            return result;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<PElement>> GetAll()
        {
            TSocketTransport transport = new TSocketTransport("server", 5550, new TConfiguration());
            TProtocol proto = new TBinaryProtocol(transport);
            PElementService.Client client = new PElementService.Client(proto);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            transport.OpenAsync(default);

            var result = await client.GetAllAsync();

            transport.Close();
            return result;
        }
    }
}
