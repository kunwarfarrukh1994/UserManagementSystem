using BussinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SampleWebApi.AuthorizationHandlers
{
    
    public class UserAuthorizationHandler :
    AuthorizationHandler<OperationAuthorizationRequirement>
    {


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement)
        {

            var s = context.User.Identity.Name;

            if (context.User != null)
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    if (context.User.Claims.Any(c => string.Equals(c.Type, requirement.Name, StringComparison.OrdinalIgnoreCase)))
                    {
                        context.Succeed(requirement);
                    }
                }  
            }
            return Task.CompletedTask;
        }
    }
}
