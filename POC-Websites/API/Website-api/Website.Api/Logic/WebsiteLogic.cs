using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Api.Entities;
using Website.Api.Interfaces;

namespace Website.Api.Logic
{
    public class WebsiteLogic
    {
        private readonly IWebsite _websiteRepo;

        public WebsiteLogic(IWebsite websiteRepo)
        {
            _websiteRepo = websiteRepo;
        }

        public Results AddWebsite(WebsiteModel model)
        {
            try
            {               
                var result = _websiteRepo.AddWebsite(model);

                if(result == 1)
                {
                    return new Results()
                    {
                        Message = "Successfully Created A Website",
                        ResultDate = DateTime.Now.Date,
                        GlobalKey = Guid.NewGuid().ToString().Substring(3, 10).ToUpper()
                    };
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public List<WebsiteModel> GetWebsites()
        {
            try
            {
                var websites = _websiteRepo.GetWebsites();
                if (websites != null)
                {
                    return websites;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
