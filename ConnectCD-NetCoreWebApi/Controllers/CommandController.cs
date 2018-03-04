using Microsoft.AspNetCore.Mvc;
using ConnectCD.NetCoreWebApi.Models;
using ConnectCD.NetCoreWebApi.WordRank;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConnectCD.NetCoreWebApi.Controllers
{
    public class CommandController : Controller
    {
        private ILogger<CommandController> _logger;

        public CommandController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> TopWords([FromQuery] string command, string text, string user_name)
        {            
            if (!string.IsNullOrEmpty(text))
            {
                var topWords = await new WordRanker(new WordDataHandler(), _logger).GetTopWordsAsync(10);
                return Ok(topWords);
            }
            
            return Ok();
        }
    }
}