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
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int TableNumber { get; set; }
        public double TotalAmount => OrderItems.Sum(i => i.Amount);
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public Color Color => _orderStatusColorMap[Status];

        private static readonly IReadOnlyDictionary<OrderStatus, Color> _orderStatusColorMap =
            new Dictionary<OrderStatus, Color>
            {
                [OrderStatus.Created] = Colors.Yellow,
                [OrderStatus.InProgress] = Colors.Blue,
                [OrderStatus.Done] = Colors.Green,
                [OrderStatus.Cancelled] = Colors.Red,
            };
    }
}
