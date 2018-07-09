using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authenticate.Api.Entities;
using Authenticate.Api.Helpers;
using Authenticate.Api.Interfaces;
using Authenticate.Api.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Authenticate.Api.Controllers
{
    [Authorize]
    [Route("token")]   
    public class TokenController : Controller
    {
        private readonly TokenLogic _logic;
        public TokenController(  TokenLogic logic)
        {          
            _logic = logic;
        }
 
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("You are Authorized !!!");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            
            try
            {
                var token = _logic.GetToken(request);
                if(token != null)
                    return Ok(token);
                else
                    return BadRequest("Username/Password are invalid!");
            }
            catch (Exception ex)
            {
                throw ex;
                
            }

         
        }

    }
}
