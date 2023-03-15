using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskmaster.Models
{
    public class SkillTaskPair
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public virtual Skill skill { set; get; }

        public virtual Task Task { set; get; }
    }
}