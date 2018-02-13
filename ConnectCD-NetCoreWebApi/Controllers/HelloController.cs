using Microsoft.AspNetCore.Mvc;

namespace ConnectCD_NetCoreWebApi.Controllers
{
    public class HelloController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World!");
        }
    }
}