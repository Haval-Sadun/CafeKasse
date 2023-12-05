using CafeKasse.MAUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class CartItemService
    {
        private readonly OrderService _orderService;
        public static IEnumerable<CartItem> _cartItems = new List<CartItem>();
        public CartItemService(OrderService orderService) 
        {
            _orderService = orderService;
        }

        // we Get the Cart items for the selected order 
        public IEnumerable<CartItem> GetCartItemsForOrder(int orderId) => _cartItems.Where(ci => ci.OrderId == orderId);
        public IEnumerable<CartItem> GetCartItems() => _cartItems;
    }
}
