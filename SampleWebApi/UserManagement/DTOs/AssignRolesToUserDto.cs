using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DTOs
{
    public class AssignRolesToUserDto
    {
        public Guid UserID { get; set; }
        public List<string> Roles {get;set;}

        public AssignRolesToUserDto()
        { 
            
        }
    }
}
