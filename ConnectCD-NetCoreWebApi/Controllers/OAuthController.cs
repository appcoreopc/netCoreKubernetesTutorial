using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectCD.NetCoreWebApi.Models;
using ConnectCD.NetCoreWebApi.Configuration;
using ConnectCD_NetCoreWebApi.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ConnectCD.NetCoreWebApi.WordRank;
using Newtonsoft.Json;

namespace ConnectCD.NetCoreWebApi.Controllers
{
    public class OAuthController : Controller
    {
        private AppConfig _settings;

        private readonly ILogger<HelloController> _logger;

        public OAuthController(IOptions<AppConfig> appSettings, ILogger<HelloController> logger)
        {
            _settings = appSettings?.Value;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] EventMessageModel model)
        {
            // Return challenge from slack if this is a challenge request 
            if (model?.Challenge != null)
            {
                return Ok(model.Challenge);
            }

            // Otherwise do word count //
            await new WordRanker(new WordDataHandler(), _logger).Collect(model?.Event.Text);

            // logging information as json string //
            _logger.LogInformation(JsonConvert.SerializeObject(model));          
        
            // Return OK to acknowledge
            // message received //

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> TopWords()
        {            
            var topWords = await new WordRanker(new WordDataHandler(), _logger).GetTopWordsAsync(10);
            return Ok(topWords);
        }               

    }
}