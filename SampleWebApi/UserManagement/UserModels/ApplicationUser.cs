using Microsoft.AspNetCore.Identity;
using System;
using System.Text;

namespace UserManagement.UserModels
{
    public class ApplicationUser:IdentityUser
    {
        public int Address { get; set; }
        public ApplicationUser() 
        {
        
        }
    }
}
