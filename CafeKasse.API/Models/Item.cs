using System.ComponentModel.DataAnnotations;

namespace CafeKasse.API.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual OrderItem? OrderItem { get; set; }
    }
}
