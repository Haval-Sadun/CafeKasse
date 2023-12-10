using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using CafeKasse.MAUI.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
    [QueryProperty(nameof(Table), nameof(Table))]
    public partial class CategoryViewModel : ObservableObject
    {
        private Random random = new Random();

        private readonly CategoryService _categoryService;
        private readonly ItemService _itemService;

        private readonly OrderItemService _orderItemService;
        private readonly TableService _tableService;
        private readonly OrderService _orderService;
        public CategoryViewModel(CategoryService categoryService, ItemService itemService,
                                OrderService orderService, OrderItemService orderItemService, TableService tableService)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _tableService = tableService;
        }

        public ObservableCollection<Item> Items { get; set; } = new();
        public ObservableCollection<Table> Tables { get; set; } = new();
        public ObservableCollection<Item> ItemsPerCategory { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

        // Collections for the Order and the order items 
        public ObservableCollection<OrderItem> OrderItems { get; set; } = new();
        public ObservableCollection<Order> Orders { get; set; } = new();

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Order))]
        private Table? _table;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(ItemsPerCategory))]
        private Category? _category;

        [ObservableProperty]
        private Item? _item;

        [ObservableProperty]
        private Order? _order;

        //executed by toolkit for the observable property "Category"
        partial void OnCategoryChanged(Category? cat)
        {
            InitializeItemProCategory();
        }

        partial void OnTableChanged(Table value)
        {
            InitializeOrders();
            if (value.State != TableStatus.Occupied)
            {
                value.State = TableStatus.Occupied;
                var or = new Order { Id = GenerateRandomId(3, 100), TableNumber = value.TableNumber };
                _orderService.AddOrder(or);
                Order = or;
            }
            else
                Order = _orderService.GetOrdersByTableNumber(value.TableNumber);
            //Toast.Make($" order id {Order.Id} for Table {value.TableNumber}").Show();

        }

        public void InitializeItemProCategory()
        {
            if (Category is not null)
            {
                ItemsPerCategory.Clear();
                var itCat = _itemService.GetItemForCategory(Category.Id);
                foreach (var ic in itCat)
                {
                    ItemsPerCategory.Add(ic);
                }
            }
        }

        public async void InitializeOrders()
        {
            var orders = _orderService.GetAllOrders();
            var tables = await _tableService.GetAllTables();
            foreach (var order in orders)
                Orders.Add(order);
            foreach (var table in tables)
                Tables.Add(table);
        }
        public async void Initialize()
        {
            var items = _itemService.GetAllItems();
            var categ = _categoryService.GetAllCategories();
            var orderItems = _orderItemService.GetOrderItems();
            var orders = _orderService.GetAllOrders();
            var tables = await _tableService.GetAllTables();

            foreach (var cat in categ)
                Categories.Add(cat);
            foreach (var it in items)
                Items.Add(it);
            foreach (var orderitem in orderItems)
                OrderItems.Add(orderitem);
            foreach (var order in orders)
                Orders.Add(order);
            foreach (var table in tables)
                Tables.Add(table);

        }

        [RelayCommand]
        private void SelectedCategory_Changed(Category category)
        {
            Category = category;
        }

        [RelayCommand]
        private void SelectedItem_Changed(Item item)
        {
            Item = item;
        }

        // if table status is ocuppied and table.orderId exists for an order with status confirmed then add the item to order 
        // if the order item doesn't exist create a new one with quantity 1 else increase the quantity++
        private void AddOrderItem()
        {
            //if the orders has selected item then increase it 
            var orderItem = OrderItems.FirstOrDefault(i => i.ItemId == Item.Id);

            if (Table.State == TableStatus.Occupied && (Order.Status == OrderStatus.Created && Order.TableNumber == Table.TableNumber))
                if (orderItem is null)
                    OrderItems.Add(new OrderItem { Id = GenerateRandomId(2, 100), ItemId = Item.Id, ItemName = Item.Name, Quantity = 1, Price = Item.Price, OrderId = Order.Id });
                else orderItem.Quantity++;
        }



        public int GenerateRandomId(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
    }
}
