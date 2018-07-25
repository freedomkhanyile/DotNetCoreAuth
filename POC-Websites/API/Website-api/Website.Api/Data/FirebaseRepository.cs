using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Api.Interfaces;
using Website.Api.Entities; 
using Microsoft.Extensions.Configuration;
using FirebaseNet.DataLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Website.Api.Data
{
    public class FirebaseRepository : IBase
    {
        private readonly IConfiguration _configuration;
        private readonly FirebaseDB _firebase;
        private readonly FirebaseDB _nodeWebsite;
        public FirebaseRepository (IConfiguration configuration)
        {
            _configuration = configuration;
            _firebase = new FirebaseDB(_configuration["FirebaseUrl"]);
            _nodeWebsite = _firebase.Node("Websites");
        }
        public int AddWebsite(string model)
        {
            try
            {
                var websites = GetWebsites();
                if(websites != null)
                {
                    var path = "W" + (websites.Count + 1).ToString();
                    var response = _nodeWebsite.NodePath(path).Put(model);

                    var newList = GetWebsites();

                    if (response.Success && newList.Count > websites.Count)
                        return 1;
                }
                else
                {
                    var response = _nodeWebsite.NodePath("W1").Put(model);
                    if (response.Success)
                        return 1;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 0;
        }

        public List<WebsiteModel> GetWebsites()
        {
            try
            {
                var response = _nodeWebsite.Get();
                if (response.Success)
                {
                    if(response.JSONContent != "null")
                    {
                        dynamic tempdata = JsonConvert.DeserializeObject<dynamic>(response.JSONContent);
                        var list = ((IDictionary<string, JToken>)tempdata)
                                    .Select(d => JsonConvert.DeserializeObject<WebsiteModel>(d.Value.ToString())).ToList();
                        return list;
                    }                     
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
