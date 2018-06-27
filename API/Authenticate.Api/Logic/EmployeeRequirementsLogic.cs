using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Logic
{
    public class EmployeeRequirementsLogic : IAuthorizationRequirement
    {
        public int MinimumMonthsEmployed { get; private set; }

        public EmployeeRequirementsLogic(int minimumMonths)
        {
            this.MinimumMonthsEmployed = minimumMonths;
        }
    }
}
