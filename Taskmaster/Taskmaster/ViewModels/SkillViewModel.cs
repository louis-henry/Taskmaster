using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class SkillViewModel
    {
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        public string CategoryName { get; set; }
    }
}
