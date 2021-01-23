using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace UserManagement.DTOs
{
    public class AssignClaimsToUserDto
    {
        public Guid UserID {get;set;}

        public IList<Claim> Claims { get; set; }
    }
}
