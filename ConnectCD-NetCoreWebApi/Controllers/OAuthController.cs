using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConnectCD.NetCoreWebApi.Models;
using ConnectCD.NetCoreWebApi.Configuration;
using ConnectCD_NetCoreWebApi.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        
        //[HttpPost]
        //public IActionResult Index([FromBody] ChallengeModel model)
        //{
        //    _logger.LogInformation("OAuthController post trigged!");
        //    _logger.LogInformation(model?.Challenge);
        //    _logger.LogInformation(model?.Token);

        //    if (model != null)
        //    {
        //        return Ok(model.Challenge);
        //    }

        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Index([FromBody] EventMessageModel model)
        {

            _logger.LogInformation("OAuthController post trigged!");
            _logger.LogInformation($" Channel: {model?.Event?.Channel}");
            _logger.LogInformation($" Token : {model?.Token}");
            _logger.LogInformation($" TeamId : {model?.Team_Id}");
            
            _logger.LogInformation(model?.Type);
            _logger.LogInformation($"Text message: {model?.Event?.Text}");

                      
            return Ok();
        }



    }
}