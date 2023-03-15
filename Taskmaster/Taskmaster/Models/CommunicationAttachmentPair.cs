using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskmaster.Models
{
    public class CommunicationAttachmentPair
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public virtual Communication Communication { set; get; }

        public virtual Attachment Attachment{ set; get; }
    }
}