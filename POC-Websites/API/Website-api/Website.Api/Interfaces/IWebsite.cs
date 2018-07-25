using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Api.Entities;

namespace Website.Api.Interfaces
{
    public interface IWebsite
    {
        List<WebsiteModel> GetWebsites();
        int AddWebsite(WebsiteModel model);
    }
}
