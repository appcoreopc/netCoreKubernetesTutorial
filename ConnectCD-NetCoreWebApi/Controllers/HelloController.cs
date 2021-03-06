﻿using ConnectCD.NetCoreWebApi.Configuration;
using ConnectCD.NetCoreWebApi.LogService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace ConnectCD_NetCoreWebApi.Controllers
{
    public class HelloController : Controller
    {
        private AppConfig _settings;
        private readonly ILogger<HelloController> _logger;
        private const string HelloWorldMessage = "Hello World. V2";
        public HelloController(IOptions<AppConfig> appSettings, ILogger<HelloController> logger) 
        {
            _settings = appSettings?.Value;
            _logger = logger;
        }
        
        // GET hello/index
        [HttpGet("{id}")]
        public IActionResult Index()
        {                      
            var messageToUsers = HelloWorldMessage + DateTime.Now.ToShortTimeString();
            _logger.LogInformation(JsonConvert.ToString(messageToUsers));            
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