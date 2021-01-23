using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using UserManagement.UserModels;

namespace UserManagement.DTOs
{
    public class UserWithRolesAndClaimsDto
    {

        
        public string Token { get; set; }

        public DateTime expiration { get; set; }

        public ApplicationUser User { get; set; }

        public IList<string> UserRoles { get; set; }

        public IList<Claim> UserClaims { get; set; }
        public UserWithRolesAndClaimsDto()
        {
                
        }
    }
}
