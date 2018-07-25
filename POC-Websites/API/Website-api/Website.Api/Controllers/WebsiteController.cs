using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Api.Entities;
using Website.Api.Logic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Api.Controllers
{
    [Route("website")]
    public class WebsiteController : Controller
    {
        private readonly WebsiteLogic _websiteLogic;
        public WebsiteController(WebsiteLogic websiteLogic)
        {
            _websiteLogic = websiteLogic;
        }
        // GET: /<controller>/
        [HttpPost("AddWebsite")]
        public IActionResult AddWebsite([FromBody] WebsiteModel model)
        {
            try
            {
                return Ok(_websiteLogic.AddWebsite(model));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
