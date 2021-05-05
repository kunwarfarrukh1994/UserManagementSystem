using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.ViewModels
{
    public class ChangePasswordViewModel
    {

        [Required]

        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage ="The New Password and the Confirm Password do not match.")]
        public string ConfirmNewPassword { get; set; }
        public ChangePasswordViewModel()
        {


        }
    }
}
