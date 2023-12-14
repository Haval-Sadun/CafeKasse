using CafeKasse.MAUI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; } = Enumerable.Empty<OrderItem>();
        public DateTime Date { get; set; } = DateTime.Now;
        public int TableNumber { get; set; }
        public int TableId { get; set; }
        public double TotalAmount => OrderItems.Sum(i => i.Amount);
        public OrderStatus Status { get; set; } = OrderStatus.Created;
    }
}
