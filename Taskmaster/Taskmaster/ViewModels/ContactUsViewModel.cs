using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class ContactUsViewModel
    {
        [Required, Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public bool Sent { get; set; }
    }
}
