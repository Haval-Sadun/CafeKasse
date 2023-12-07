using CafeKasse.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CafeKasse.API.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [Required]
        public int TableNumber { get; set; }
        public double TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual Table? Table { get; set; }

    }
}
