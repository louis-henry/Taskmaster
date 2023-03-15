using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { set; get; }

        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }

        public IEnumerable<SkillViewModel> Skills { set; get; }
    }
}
