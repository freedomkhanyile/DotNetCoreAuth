using Authenticate.Api.Entities;
using Authenticate.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Logic
{
    public class TokenLogic
    {
        private readonly IToken _token;
        public TokenLogic(IToken token)
        {
            _token = token;
        }

        public TokenResponse GetToken(TokenRequest request)
        {
            return _token.RequestToken(request);
        }
    }
}
