using lastProj.Models;
using System.ComponentModel.DataAnnotations;

namespace lastProj.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
