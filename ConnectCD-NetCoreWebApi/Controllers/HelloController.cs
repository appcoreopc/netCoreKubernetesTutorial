using ConnectCD.NetCoreWebApi.Configuration;
using ConnectCD.NetCoreWebApi.LogService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace ConnectCD_NetCoreWebApi.Controllers
{
    public class HelloController : Controller
    {
        private AppConfig _settings;

        public HelloController(IOptions<AppConfig> appSettings)
        {
            _settings = appSettings?.Value;
        }
        
        // GET hello/index
        [HttpGet("{id}")]
        public IActionResult Index()
        {
            var logger = new FluentdLogger(_settings.Settings);
            var messageToUsers = "Hello World! " + DateTime.Now.ToShortTimeString();
            logger.Write(messageToUsers);
            return Ok(messageToUsers);
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
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}