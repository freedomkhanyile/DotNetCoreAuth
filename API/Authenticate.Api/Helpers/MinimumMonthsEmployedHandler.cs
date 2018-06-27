using Authenticate.Api.Logic;
using Microsoft.AspNetCore.Authorization;
using NodaTime;
using NodaTime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.Api.Helpers
{
    public class MinimumMonthsEmployedHandler : AuthorizationHandler<EmployeeRequirementsLogic>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            EmployeeRequirementsLogic requirement)
        {
            var emplomentCommenced = context.User
                .FindFirst(claim => claim.Type == CustomClaimTypes.EmploymentCommenced).Value;

            var employmentStarted = Convert.ToDateTime(emplomentCommenced);
            var today = LocalDate.FromDateTime(DateTime.Now);

            var monthsPassed = Period
                .Between(employmentStarted.ToLocalDateTime(), today.AtMidnight()).Months;

            if(monthsPassed >= requirement.MinimumMonthsEmployed)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public static class CustomClaimTypes
    {
        public const string EmploymentCommenced = "EmploymentCommenced";
    }
}
