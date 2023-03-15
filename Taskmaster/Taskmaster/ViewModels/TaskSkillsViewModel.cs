using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Taskmaster.Models;
using Taskmaster.Shared;

namespace Taskmaster.ViewModels
{
    public class TaskSkillsViewModel
    {
        public int ID { set; get; }

        public TaskType Type { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Postcode { set; get; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? StartDate { set; get; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EndDate { set; get; }

        public virtual ICollection<TaskAttachmentPair> Attachment { set; get; }

        [Display(Name="Level of presence")]
        public PresenceLevel PresenceLevel { set; get; }

        [DataType(DataType.Currency)]
        public decimal Payment { set; get; }

        public int SelectedSkillId { get; set; }

        public IEnumerable<SkillViewModel> Skills { set; get; }

        public List<SelectListItem> Categories { get; set; }
    }
}
