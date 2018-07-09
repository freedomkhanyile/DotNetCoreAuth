using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Entities
{
    public class User
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Role")]
        public string Role { get; set; }

    }
}
