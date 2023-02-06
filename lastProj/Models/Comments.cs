using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using lastProj.Models;

namespace lastProj.Models
{
    public class Comment
    {
        //Relationship
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal? Animal { get; set; }

        [Required(ErrorMessage ="plz enter a comment to submit")]

        [DataType(DataType.MultilineText)]
        public string? Comments { get; set; }

    }
}
