using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HttpServer
{
    [Route("starter")]
    [EnableCors("AllowAllOrigins")]
    public class StarterController : Controller
    {
        [HttpGet]
        [Route("start")]
        public IActionResult StartGet()
        {
            Console.WriteLine("Method get is called");
            return Ok(new { data = "get server data" });
        }

        [HttpPost]
        [Route("start")]
        public IActionResult StartPost()
        {
            Console.WriteLine("Method post is called");
            return Ok(new {data="post server data"});
        }
    }
}