using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskmaster.Models
{
    public class TaskAttachmentPair
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public Task Task { set; get; }

        public int Attachment { set; get; }
    }
}
