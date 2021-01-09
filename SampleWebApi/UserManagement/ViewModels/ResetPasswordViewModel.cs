using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The  Password and the Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string token { get; set; }

        public ResetPasswordViewModel()
        {
                
        }
    }
}
