using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UserManagement.UserModels;

namespace UserManagement.DTOs
{
    public class UserWithRolesDto
    {

        
        public string Token { get; set; }

        public DateTime expiration { get; set; }

        public ApplicationUser User { get; set; }

        public IList<string> UserRoles { get; set; }
        public UserWithRolesDto()
        {
                
        }
    }
}
