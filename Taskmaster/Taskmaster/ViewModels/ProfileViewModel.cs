using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskmaster.Models;

namespace Taskmaster.ViewModels
{
    public class ProfileViewModel
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

        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        public string Description { get; set; }

        public virtual Attachment ProfilePicture { set; get; }

        [Required, Display(Name="Profile viewable by public?")]
        public bool PublicProfile { set; get; }
        //Limited Field Options for State
        public List<string> _States { get; set; } = new List<string> {"Australian Capital Territory","New South Wales","Northern Territory","Queensland","Tasmania",
                "South Australia" ,"Victoria","Western Australia", "Other"};

        public IEnumerable<CategoryViewModel> Categories { set; get; }


        /*   public virtual ApplicationUser AspUser { set; get; }

           public virtual ICollection<Task> Tasks { set; get; }*/

    }
}
