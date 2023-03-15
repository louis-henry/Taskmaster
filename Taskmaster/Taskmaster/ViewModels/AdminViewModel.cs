using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<string> Yaxis { get; set; }

        public IEnumerable<BarViewModel> Xaxis { get; set; }

        public AdminPanelViewModel YourTasks { get; set; }

        public AdminPanelViewModel ActiveTasks { get; set; }

        public AdminPanelViewModel CompletedTasks { get; set; }
    }
}
