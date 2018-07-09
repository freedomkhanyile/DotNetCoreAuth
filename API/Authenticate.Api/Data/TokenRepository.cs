using Authenticate.Api.Entities;
using Authenticate.Api.Helpers;
using Authenticate.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authenticate.Api.Data
{
    public class TokenRepository : IToken
    {
        private readonly IConfiguration _configuration;

        public TokenRepository (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string RequestToken(TokenRequest request)
        {
            if(request.Username == "Test")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim("CompleteHRProcess",""),
                    new Claim(CustomClaimTypes.EmploymentCommenced,
                               new DateTime(2018,10,04).ToString(),
                               ClaimValueTypes.DateTime)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds
                    );
                
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }
    }
}
