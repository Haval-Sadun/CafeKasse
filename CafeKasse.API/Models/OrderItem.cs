using System.ComponentModel.DataAnnotations;

namespace CafeKasse.API.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
