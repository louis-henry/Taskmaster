﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.ViewModels
{
    public class EmailViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
