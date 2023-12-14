using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.ViewModels
{
    public partial class OrderItemViewModel : ObservableObject
    {
        private readonly OrderService _orderService;
        private readonly OrderItemService _orderItemService;

        public OrderItemViewModel(OrderService orderService, OrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }
        public ObservableCollection<OrderItem> OrderItems { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;
        [ObservableProperty]
        private Order _order;

        public async void InitializeOrderItems(Order order)
        {
            if (order != null)
            {
                OrderItems.Clear();
                var ordItems = await _orderItemService.GetOrderItemsByOrder(order.Id);

                foreach (var ordItem in ordItems)
                {
                    OrderItems.Add(ordItem);
                }
                RecalculateTotalAmount();
            }
        }

        private void RecalculateTotalAmount() =>
            TotalAmount = OrderItems.Sum(c => c.Amount);

        [RelayCommand]
        private void IncreaseOrderItemQuantity(Guid orderItemId)
        {
            var item = OrderItems.FirstOrDefault(c => c.Id == orderItemId);
            if (item is not null)
            {
                item.Quantity++;
                RecalculateTotalAmount();
            }
        }

        [RelayCommand]
        private async Task AddToCartAsync(Item item)
        {
            var it = OrderItems.FirstOrDefault(c => c.ItemId == item.Id);
            if (it is not null)
            {
                it.Quantity++;
                await _orderItemService.UpdateOrderItemAsync(it, it.Id);
            }
            else
            {
                it = await _orderItemService.SaveOrderItemAsync(new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = item.Id,
                    ItemName = item.Name,
                    OrderId = Order.Id,
                    Price = item.Price,
                    Quantity = 1
                });
                OrderItems.Add(it);
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async Task RemoveFromCartAsync(int itemId)
        {
            var it = OrderItems.FirstOrDefault(c => c.ItemId == itemId);
            if (it is not null)
            {
                if (it.Quantity == 1)
                {
                    OrderItems.Remove(it);
                    await _orderItemService.DeleteOrderItemAsync(it.Id);
                }
                else
                {
                    it.Quantity--;
                    await _orderItemService.UpdateOrderItemAsync(it, it.Id);
                }
            }
            RecalculateTotalAmount();
        }

        private void ClearCart()
        {
            OrderItems.Clear();
            RecalculateTotalAmount();
        }

    }
}
