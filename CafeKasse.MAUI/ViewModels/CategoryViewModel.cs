using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using CafeKasse.MAUI.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace CafeKasse.MAUI.ViewModels
{
    [QueryProperty(nameof(Table), nameof(Table))]
    public partial class CategoryViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        private readonly ItemService _itemService;

        private readonly OrderItemService _orderItemService;
        private readonly OrderService _orderService;
        public CategoryViewModel(CategoryService categoryService, ItemService itemService,
                                OrderService orderService, OrderItemService orderItemService,
                                TableService tableService, HomeViewModel tableViewModel)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        public ObservableCollection<Item> Items { get; set; } = new();
        public ObservableCollection<Item> ItemsPerCategory { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

        public ObservableCollection<OrderItem> ItemsPerOrder { get; set; } = new();
        public ObservableCollection<Order> Orders { get; set; } = new();


        [ObservableProperty,
            NotifyCanExecuteChangedFor(nameof(InitializeItemsPerOrderCommand))]
        private Table? _table;

        [ObservableProperty]
        private Category? _category;

        [ObservableProperty]
        private Item? _item;

        [ObservableProperty]
        private Order? _order;

        [ObservableProperty]
        private OrderItem? _orderItem;
        [ObservableProperty]
        private double _totalAmount;
        private void RecalculateTotalAmount() => TotalAmount = ItemsPerOrder?.Sum(c => c?.Amount ?? 0) ?? 0;

        partial void OnTableChanged(Table? value) => InitializeOrderProTableCommand.Execute(value);
        partial void OnCategoryChanged(Category? cat) => InitializeItemProCategory();
        partial void OnItemChanged(Item? value)
        {
            OrderItem = ItemsPerOrder?.FirstOrDefault(oi => oi?.ItemId == value?.Id) ?? null;
            //Toast.Make($"the value of order Item is : {OrderItem}", ToastDuration.Short).Show();
        }

        public async void Initialize()
        {
            var items = await _itemService.GetAllItems();
            var categ = await _categoryService.GetAllCategories();
            var orders = await _orderService.GetAllOrders();
            foreach (var cat in categ)
                Categories.Add(cat);
            foreach (var it in items)
                Items.Add(it);
            foreach (var order in orders)
                Orders.Add(order);
        }

        [RelayCommand]
        public async void InitializeItemProCategory()
        {
            if (Category is not null)
            {
                ItemsPerCategory.Clear();
                var itCat = await _itemService.GetItemForCategory(Category.Id);
                foreach (var ic in itCat)
                {
                    ItemsPerCategory.Add(ic);
                }
            }
        }
        [RelayCommand]
        private async void InitializeOrderProTable(Table table)
        {
            if (Table is not null)
            {
                Order = await _orderService.GetOrderByTableNumber(table.TableNumber);
                InitializeItemsPerOrderCommand.Execute(Order);
            }
        }
        [RelayCommand]
        private async void InitializeItemsPerOrder(Order ord)
        {
            if (ord is not null)
            {
                ItemsPerOrder.Clear();
                var ordItm = await _orderItemService.GetOrderItemsByOrder(ord.Id);
                foreach (var oi in ordItm)
                {
                    ItemsPerOrder.Add(oi);
                }
                RecalculateTotalAmount();
            }
        }



        [RelayCommand]
        private void SelectedCategory_Changed(Category category) => Category = category;

        [RelayCommand]
        private void SelectedItem_Changed(Item item)
        {
            Item = item;
            AddToCart(Item);

        }
        private async Task AddToCart(Item item) => await UpdateCartAsync(item, 1);
        [RelayCommand]
        private async Task RemoveFromCart(Item item) => await UpdateCartAsync(item, -1);
        private async Task UpdateCartAsync(Item item, int count)
        {
            if (item is not null)
            {
                if (Order is null)
                {
                    Order = await _orderService.SaveOrderAsync(new Order()
                    {
                        TableNumber = Table.TableNumber,
                        TableId = Table.Id
                    });
                    Orders.Add(Order);
                }
                if (count == 1)
                {
                    if (OrderItem is not null)
                    {
                        OrderItem.Quantity++;
                        await _orderItemService.UpdateOrderItemAsync(OrderItem, OrderItem.Id);

                    }
                    else
                    {
                        OrderItem = await _orderItemService.SaveOrderItemAsync(new OrderItem
                        {
                            Id = Guid.NewGuid(),
                            ItemId = item.Id,
                            ItemName = item.Name,
                            OrderId = Order.Id,
                            Price = item.Price,
                            Quantity = 1
                        });
                        ItemsPerOrder.Add(OrderItem);
                    }
                    RecalculateTotalAmount();
                }
                /*else if (count == -1)
                {
                    _orderItemViewModel.RemoveFromCartCommand.Execute(item);
                }*/
            }
        }

    }
}
