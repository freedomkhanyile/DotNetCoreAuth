using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Api.Entities
{
    public class WebsiteModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string Status { get; set; }

        public string Publisher { get; set; }

        public string DatePublished { get; set; }
    }
}
