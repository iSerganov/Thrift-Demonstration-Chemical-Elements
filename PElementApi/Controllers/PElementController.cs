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
        public async Task<ApiResult<PElement>> Get(string name)
        {
            TSocketTransport transport = new TSocketTransport("server", 5550, new TConfiguration());
            TProtocol proto = new TBinaryProtocol(transport);
            PElementService.Client client = new PElementService.Client(proto);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            transport.OpenAsync(default);

            try
            {
                PElement result = await client.GetAsync(name);
                return new ApiResult<PElement>()
                {
                    Result = result,
                    Success = true
                };
            }
            catch (TApplicationException)
            {
                return new ApiResult<PElement>()
                {
                    Result = null,
                    Error = "Element not found"
                };
}
            finally
            {
                transport.Close();
            }

        }

        [HttpGet("All")]
        public async Task<ApiResult<IEnumerable<PElement>>> GetAll()
        {
            TSocketTransport transport = new TSocketTransport("server", 5550, new TConfiguration());
            TProtocol proto = new TBinaryProtocol(transport);
            PElementService.Client client = new PElementService.Client(proto);
            try
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                transport.OpenAsync(default);

                var result = await client.GetAllAsync();

                
                return new ApiResult<IEnumerable<PElement>>()
                {
                    Result = result,
                    Success = true
                };
            } catch (Exception ex)
            {
                return new ApiResult<IEnumerable<PElement>>()
                {
                    Result = null,
                    Success = false,
                    Error = ex.Message
                };
            } finally
            {
                transport.Close();
            }
        }
    }
}
