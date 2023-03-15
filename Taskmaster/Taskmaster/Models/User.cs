using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskmaster.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required]
        public bool PublicProfile { set; get; }

        public virtual ApplicationUser AspUser { set; get; }

        public virtual ICollection<SkillUserPair> Skills { set; get; }

        public virtual ICollection<Task> Tasks { set; get; }
    }
}
