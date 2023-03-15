using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class SkillManagementViewModel
    {
        public int ID { set; get; }

        public IEnumerable<SkillViewModel> Skills { set; get; }

        public List<SelectListItem> Categories { get; set; }
    }
}
