using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace UserManagement.DTOs
{
    public class AddClaimsToRoleDto
    {
        public Guid RoleID { get; set; }
        public IList<string> ClaimTypes { get; set; }

        public AddClaimsToRoleDto(){}
    }
}
