using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XRayServerless.Clients;

namespace XRayServerless.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMyGitHubClient _gitHubClient;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IMyGitHubClient gitGitHubClient, ILogger<ValuesController> logger)
        {
            _gitHubClient = gitGitHubClient;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogInformation("Hit the GET endpoint of values controller");
            var result = await _gitHubClient.GetRootDataLength();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _logger.LogError("Hit GET individual value endpoint, no real data accessed");
            return $"value {id}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
