using CafeKasse.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class OrderItemService
    {
        private readonly OrderService _orderService;
        public static IEnumerable<OrderItem> _orderItems = new List<OrderItem>();
        public OrderItemService(OrderService orderService) 
        {
            _orderService = orderService;
        }

        // we Get the Cart items for the selected order 
        public IEnumerable<OrderItem> GetOrderItemsForOrder(int orderId) => _orderItems.Where(ci => ci.OrderId == orderId);
        public IEnumerable<OrderItem> GetOrderItems() => _orderItems;
    }
}
