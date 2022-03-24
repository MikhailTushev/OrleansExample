using System;
using System.Threading.Tasks;
using GrainsInterface;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace OrleansClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrainController : ControllerBase
    {
        private readonly IClusterClient _client;

        public GrainController(IClusterClient client)
        {
            _client = client;
        }

        [HttpGet]
        public Task<string> Get([FromQuery] string name)
        {
            var value = string.IsNullOrEmpty(name) ? Guid.NewGuid().ToString("N") : name;

            return _client.GetGrain<IHelloWorldGrain>(value).HelloByName(value);
        }
    }
}