using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CafeKasse.MAUI.ViewModels
{
    public partial class OrderViewModel: ObservableObject
    {
        private readonly OrderItemService _cartItemService;
        private readonly OrderService _orderService;

        public OrderViewModel(OrderItemService cartItemService, OrderService orderService)
        {
            _cartItemService = cartItemService;
            _orderService = orderService;

            OrderItems = new(_cartItemService.GetOrderItems());
            Orders = new(_orderService.GetAllOrders());
        }
        public ObservableCollection<OrderItem> OrderItems { get; set; } 
        public ObservableCollection<Order> Orders { get; set; } 


        [ObservableProperty]
        private double _totalAmount;

        private void RecalculatTotalAmount() => TotalAmount = (double)OrderItems.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateOrderItems(OrderItem cartItem)
        {
            var item = OrderItems.FirstOrDefault(c => c.Id == cartItem.Id);
            if (item is not null)
            {
                item.Quantity++;
            }
            else
            {
                OrderItems.Add(cartItem.Clone());
            }
            RecalculatTotalAmount();
        }

        [RelayCommand]
        private void RemoveOrderItem(OrderItem cartItem)
        {
            var item = OrderItems.FirstOrDefault(c => c.Id == cartItem.Id);
            if (item != null)
            {
                if(item.Quantity > 0)
                    item.Quantity--;
                else
                    OrderItems.Remove(cartItem);
                RecalculatTotalAmount();
            }
        }

        [RelayCommand]
        private async Task ClearCart()
        {
            var result = await Shell.Current.DisplayAlert("Confirm Clear Cart?", "are you sure you wanna clear everything from the Cart?", "OK", "Cancel");
            if (result)
            {
                OrderItems.Clear();
                RecalculatTotalAmount();
                await Toast.Make("Category has been attached", ToastDuration.Short).Show();
            }
        }
        [RelayCommand]
        private async Task PlaceOrder()
        {
            OrderItems.Clear();
            RecalculatTotalAmount();
            // navigete to payment
        }
    }
}
