using Microsoft.AspNetCore.Mvc;

namespace ConnectCD_NetCoreWebApi.Controllers
{
    public class HelloController : Controller
    {


        // GET hello/index
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World!");
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