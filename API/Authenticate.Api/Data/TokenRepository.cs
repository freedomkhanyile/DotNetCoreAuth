using Authenticate.Api.Entities;
using Authenticate.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Data
{
    public class TokenRepository : IToken
    {
        public JwtSecurityTokenHandler RequestToken(TokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
