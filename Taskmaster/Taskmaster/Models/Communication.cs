using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskmaster.Models
{
    public class Communication
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public bool New { get; set; }

        public virtual User Sender { set; get; }

        public virtual User Recipient { set; get; }
                
        public virtual Task Task { set; get; }

        [Required]
        public string Subject { set; get; }

        [Required]
        public string Details { set; get; }

        [Required]
        public DateTime Date { set; get; }
                
        public virtual ICollection<CommunicationAttachmentPair> Attachment {set; get; }

        public Communication ParentCommunication { set; get; }
    }
}
