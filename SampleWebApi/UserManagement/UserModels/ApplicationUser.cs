using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.UserModels
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Email address is required")]
        public string Address { get; set; }

        public ApplicationUser() 
        {
        
        }
    }
}
