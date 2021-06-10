using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.UserModels;

namespace SampleWebApi.ResourcesOperations
{
    public static class UserOperations
    {
        public static OperationAuthorizationRequirement SuperAdmin =
      new OperationAuthorizationRequirement { Name = UserClaimTypes.SuperAdmin };
        public static OperationAuthorizationRequirement SendMail =
            new OperationAuthorizationRequirement { Name = "SendMail" };
    }
}
