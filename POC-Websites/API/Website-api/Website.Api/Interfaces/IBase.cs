using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Api.Entities;

namespace Website.Api.Interfaces
{
    public interface IBase
    {
        int AddWebsite(string model);
        List<WebsiteModel> GetWebsites();

    }
}
