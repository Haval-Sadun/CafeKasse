using System.ComponentModel.DataAnnotations;

namespace CafeKasse.API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Item>? Items { get; set; } = null;
    }
}