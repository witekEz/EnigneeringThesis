using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UA.Model.Entities;
using UA.Model.Entities.Rate;

namespace UA.Services.Authorization
{
    public class ResourceOperationRequirementRateGenerationHandler:AuthorizationHandler<ResourceOperationRequirement,RateGeneration>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, RateGeneration rate)
        {
            if(requirement.ResourceOperation==ResourceOperation.Read)
            {
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (rate.UserID == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
