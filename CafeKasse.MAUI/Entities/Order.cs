using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

        public decimal TotalAmount => CartItems.Sum(i => i.Amount);
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public Color Color => _orderStatusColorMap[Status];

        private static readonly IReadOnlyDictionary<OrderStatus, Color> _orderStatusColorMap =
            new Dictionary<OrderStatus, Color>
            {
                [OrderStatus.Placed] = Colors.Yellow,
                [OrderStatus.Confirmed] = Colors.Blue,
                [OrderStatus.Delivered] = Colors.Green,
                [OrderStatus.Cancelled] = Colors.Red,
            };
    }
}
