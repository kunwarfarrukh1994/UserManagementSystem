using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.UserModels
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        public ApplicationUser() 
        {
        
        }
    }
}
