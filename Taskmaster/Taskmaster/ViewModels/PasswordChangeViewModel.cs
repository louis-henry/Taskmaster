using System;
using System.ComponentModel.DataAnnotations;

namespace Taskmaster.ViewModels
{
    public class PasswordChangeViewModel
    {


        [Required]
        [DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password),Display(Name ="New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password),Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
    
}

