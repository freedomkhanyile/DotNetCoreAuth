using Authenticate.Api.Entities;
using Authenticate.Api.Interfaces;
using FirebaseNet.DataLogic;
using FirebaseNet.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Data
{
    public class FirebaseRepository : IBase
    {
        private readonly IConfiguration _configuration;
        private readonly FirebaseDB _firebase;
        private readonly FirebaseDB _firebaseDBTeams;

        public FirebaseRepository (IConfiguration configuration)
        {
            _configuration = configuration;
            _firebase = new FirebaseDB(_configuration["FirebaseUrl"]);
            // Referring to Node with name "Users" in Firebase
            _firebaseDBTeams = _firebase.Node("Users");
        }
    
       
        public List<User> GetUsers()
        {
            try
            {
                var response = _firebaseDBTeams.Get();
                if(response.JSONContent != "null")
                {
                    //Deserialize JSON
                    dynamic tempData = JsonConvert.DeserializeObject<dynamic>(response.JSONContent);
                    var users = ((IDictionary<string, JToken>)tempData)
                                .Select(d => JsonConvert.DeserializeObject<User>(d.Value.ToString())).ToList();
                    return users;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
    }
}
