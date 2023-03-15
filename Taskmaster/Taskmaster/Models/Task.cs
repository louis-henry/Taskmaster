using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taskmaster.Shared;

namespace Taskmaster.Models
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public TaskType Type { set; get; }

        public virtual User Owner { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        public string Postcode { set; get; }

        public virtual ICollection<SkillTaskPair> Skills { set; get; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? StartDate { set; get; }

        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EndDate { set; get; }

        public virtual ICollection<TaskAttachmentPair> Attachment { set; get; }

        [Required]
        public PresenceLevel PresenceLevel { set; get; }

        [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Payment { set; get; }

        public Task ParentTask { set; get; }

        public bool Completed { set; get; }
    }
}