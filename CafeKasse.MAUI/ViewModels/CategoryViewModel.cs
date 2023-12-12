using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using CafeKasse.MAUI.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CafeKasse.MAUI.ViewModels
{
    [QueryProperty(nameof(Table), nameof(Table))]
    public partial class CategoryViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        private readonly ItemService _itemService;

        private readonly OrderItemService _orderItemService;
        private readonly TableService _tableService;
        private readonly HomeViewModel _tableViewModel;
        private readonly OrderService _orderService;
        public CategoryViewModel(CategoryService categoryService, ItemService itemService,
                                OrderService orderService, OrderItemService orderItemService,
                                TableService tableService, HomeViewModel tableViewModel)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _tableService = tableService;
            _tableViewModel = tableViewModel;
        }

        public ObservableCollection<Item> Items { get; set; } = new();
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

        [ObservableProperty]
        private OrderItem? _orderItem;



        //executed by toolkit for the observable property "Category"
        partial void OnCategoryChanged(Category? cat)
        {
            InitializeItemProCategory();
        }

        //partial void OnTableChanged(Table value)
        //{
        //    var order = _orderService.GetOrderByTableNumber(value.TableNumber);
        //    if (order != null)
        //        Order = order.Result;
        //    else
        //        Order = order.Result;
        ////InitializeOrders();
        //if (value.State != TableStatus.Occupied)
        //{
        //    value.State = TableStatus.Occupied;
        //    var or = new Order { Id = GenerateRandomId(3, 100), TableNumber = value.TableNumber };
        //    _orderService.AddOrder(or);
        //    Order = or;
        //}
        //else
        //    Order = await _orderService.GetOrderByTableNumber(value.TableNumber);
        //Toast.Make($" order id {Order.Id} for Table {value.TableNumber}").Show();

        //}

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

        //public async void InitializeOrders()
        //{
        //    var orders = _orderService.GetAllOrders();
        //    var tables = await _tableService.GetAllTables();
        //    foreach (var order in orders)
        //        Orders.Add(order);
        //    foreach (var table in tables)
        //        Tables.Add(table);
        //}
        public async void Initialize()
        {
            var items = await _itemService.GetAllItems();
            var categ = await _categoryService.GetAllCategories();
            var orderItems = await _orderItemService.GetOrderItems();
            var orders = await _orderService.GetAllOrders();

            foreach (var cat in categ)
                Categories.Add(cat);
            foreach (var it in items)
                Items.Add(it);
            foreach (var orderitem in orderItems)
                OrderItems.Add(orderitem);
            foreach (var order in orders)
                Orders.Add(order);

        }

        [RelayCommand]
        private void SelectedCategory_Changed(Category category)
        {
            Category = category;
            Toast.Make($" Category Name {Category.Name} for Table {Table.TableNumber}").Show();
        }

        [RelayCommand]
        private void SelectedItem_Changed(Item item)
        {
            Item = item;
            AddOrderItem();
            Toast.Make($" Item Name {Item.Name} for Category {Category.Name} and the Table {Table.TableNumber}").Show();

        }

        [RelayCommand]
        private async void AddOrderItem()
        {
            if (Item is not null && Table is not null)
            {
                var ord = await _orderService.GetOrderByTableNumber(Table.TableNumber);

                if (ord is null)
                {
                    Order = await _orderService.SaveOrderAsync(new Order() { TableNumber = Table.TableNumber, TableId = Table.Id });
                    Orders.Add(Order);

                    Table.State = TableStatus.Occupied;
                    await _tableService.UpdateTableAsync(Table, Table.Id);
                    _tableViewModel.Tables.FirstOrDefault(t => t.Id == Table.Id).State = TableStatus.Occupied;

                    OrderItem = await _orderItemService.SaveOrderItemAsync(new OrderItem
                    { ItemId = Item.Id, OrderId = Order.Id, Price = Item.Price, Quantity = 1 });
                    OrderItems.Add(OrderItem);
                }
                else
                {
                    Order = ord;

                    var ordItems = await _orderItemService.GetOrderItemsForOrder(Order.Id);

                    OrderItem = ordItems.FirstOrDefault(oi => oi.ItemId == Item.Id);

                    if (OrderItem is not null)
                    {
                        OrderItem.Quantity++;
                        OrderItems.FirstOrDefault(OrderItem).Quantity++;
                        await _orderItemService.UpdateOrderItemAsync(OrderItem, OrderItem.Id);
                    }
                    OrderItem = await _orderItemService.SaveOrderItemAsync(new OrderItem
                    { ItemId = Item.Id, OrderId = Order.Id, Price = Item.Price, Quantity = 1 });
                    OrderItems.Add(OrderItem);
                }

            }
            else
                await Toast.Make(" Please Select an Item ").Show();
        }

    }
}
