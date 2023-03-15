using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Taskmaster.Models;

namespace Taskmaster.ViewModels
{
    public class UserViewModel
    {
        public int UserID { set; get; }

        [Required]
        public string Name { set; get; }

        public string Address { set; get; }

        [StringLength(50)]
        public string City { set; get; }

        public string State { set; get; }

        public string Postcode { set; get; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { set; get; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        public string Description { get; set; }

        public virtual Attachment ProfilePicture { set; get; }

        [Required, Display(Name = "Profile viewable by public?")]
        public bool PublicProfile { set; get; }

        public bool Administrator { get; set; }

        public bool Permanent { get; set; }

        public bool Active { get; set; }

        public IEnumerable<CategoryViewModel> Categories { set; get; }
    }
}
