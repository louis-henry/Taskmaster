using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taskmaster.Models;
using Taskmaster.Shared;

namespace Taskmaster.ViewModels
{
    public class TaskViewModel : IValidatableObject
    {        
        public int ID { set; get; }

        [Required]
        public TaskType Type { set; get; }

        public ProfileViewModel Owner { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        public string Postcode { set; get; }

        public IEnumerable<CategoryViewModel> Categories { set; get; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? StartDate { set; get; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? EndDate { set; get; }

        public virtual ICollection<TaskAttachmentPair> Attachment { set; get; }

        [Required]
        public PresenceLevel PresenceLevel { set; get; }

        [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        public decimal Payment { set; get; }

        public Task ParentTask { set; get; }

        public bool Complete { get; set; }

        public List<SelectListItem> CategoriesSelect { get; set; }

        [Required(ErrorMessage = "A valid primary skill is required."), Display(Name = "Primary skill")]
        public int PrimarySkillId { get; set; }

        // Custom validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartDate != null && EndDate != null)
            {
                if (DateTime.Compare((DateTime)StartDate, (DateTime)EndDate) > 0)
                {
                    yield return new ValidationResult("Start Date must be before End Date", new List<string>() { "StartDate" });
                    yield return new ValidationResult("End Date must be after Start Date", new List<string>() { "EndDate" });
                }
            }
        }
    }
}
