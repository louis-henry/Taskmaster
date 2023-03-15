using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Taskmaster.Models
{
    /// <summary>
    /// Inherited class used to link additional database tables to Identity users.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
