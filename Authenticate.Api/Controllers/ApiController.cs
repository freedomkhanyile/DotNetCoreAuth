using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Authenticate.Api.Controllers
{
    [Authorize]
    [Route("api")]   
    public class ApiController : Controller
    {
        private readonly IConfiguration _configuration;

        public ApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
 
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("You are Authorized !!!");
        }



    }
}
