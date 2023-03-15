using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class AnalyticsViewModel
    {
        public IEnumerable<PieViewModel> TasksPerPaymentRange { get; set; }
        public string TasksPerPaymentRangeJson { get; set; }

        public IEnumerable<PieViewModel> TaskPerType { get; set; }
        public string TaskPerTypeJson { get; set; }

        public IEnumerable<PieViewModel> TasksPerPresence { get; set; }
        public string TasksPerPresenceJson { get; set; }
    }
}
