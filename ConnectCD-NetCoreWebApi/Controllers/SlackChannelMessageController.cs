using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectCD.NetCoreWebApi.Models;
using Microsoft.Extensions.Logging;
using ConnectCD.NetCoreWebApi.Configuration;
using Microsoft.Extensions.Options;

namespace ConnectCD.NetCoreWebApi.Controllers
{
    public class SlackChannelMessageController : Controller
    {
        private AppConfig _settings;
        private readonly ILogger<SlackChannelMessageController> _logger;

        public SlackChannelMessageController(IOptions<AppConfig> appSettings, ILogger<SlackChannelMessageController> logger)
        {
            _settings = appSettings?.Value;
            _logger = logger;
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult GetMessage([FromBody]  EventMessageModel message)
        {


            return Ok();
        }
    }
}