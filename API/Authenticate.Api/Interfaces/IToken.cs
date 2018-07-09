using Authenticate.Api.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Interfaces
{
    public interface IToken
    {
        string RequestToken(TokenRequest request);
    }
}
