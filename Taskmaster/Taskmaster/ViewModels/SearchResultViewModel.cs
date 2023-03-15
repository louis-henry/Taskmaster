using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskmaster.Shared;

namespace Taskmaster.ViewModels
{
    public class SearchResultViewModel
    {
        public ResultType Type { get; set; }

        public int Id { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Price { get; set; }
    }
}
