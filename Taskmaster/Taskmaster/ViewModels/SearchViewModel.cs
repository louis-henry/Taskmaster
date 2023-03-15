using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskmaster.Shared;

namespace Taskmaster.ViewModels
{
    public class SearchViewModel
    {
        public string Term { get; set; }

        public SearchType Type { get; set; }

        public IEnumerable<SearchResultViewModel> Results { get; set; }

        public int Profiles { get; set; }

        public int Tasks { get; set; }

        public IEnumerable<KeyValuePair<string, int>> Categories { get; set; }

    }
}
