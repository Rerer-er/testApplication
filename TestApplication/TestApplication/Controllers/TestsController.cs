using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        //[HttpGet(Name = "GetKinds"), Authorize]
        [HttpGet]
        public IActionResult GetValues()
        {
            
            return Ok("qweqweqweqweqweqweqweqweqwe");
        }
    }
}
