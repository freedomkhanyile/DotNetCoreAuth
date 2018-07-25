﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Api.Entities;
using Website.Api.Interfaces;

namespace Website.Api.Data
{
    public class WebsiteRepository : IWebsite
    {
        private readonly IBase _firebase;
        public WebsiteRepository(IBase firebase)
        {
            _firebase = firebase;
        }

        public int AddWebsite(WebsiteModel model)
        {
          return _firebase.AddWebsite(JsonConvert.SerializeObject(model));
        }
    }
}
