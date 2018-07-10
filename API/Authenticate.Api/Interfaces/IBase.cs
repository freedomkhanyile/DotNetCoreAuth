using Authenticate.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Interfaces
{
    public interface IBase
    {
        List<User> GetUsers();
    }
}
