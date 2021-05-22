using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orleans;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orleans_Pet
{
    public class HelloWorldController : Controller
    {
        private readonly IClusterClient _clusterClient;

        public HelloWorldController(IClusterClient clusterClient)
        {
            this._clusterClient = clusterClient;
        }

        [HttpGet("/hello/{name}")]
        public async Task<IActionResult> Hello(string name)
        {
            var result = await _clusterClient.GetGrain<IHelloWorldGrain>("Stu").SayHelloAsync(name);
            return Ok(result);
        }
    }
}
