using CafeKasse.MAUI.Entities;
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
    [QueryProperty(nameof(Table),nameof(Table))]
    public partial class CategoryViewModel : ObservableObject
    {
        

        private readonly CategoryService _categoryService;
        private readonly ItemService _itemService;

        private readonly CartItemService _cartItemService;
        private readonly OrderService _orderService;
        public CategoryViewModel(CategoryService categoryService, ItemService itemService, OrderService orderService, CartItemService cartItemService = null)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _orderService = orderService;
            _cartItemService = cartItemService;
        }

        public ObservableCollection<Item> Items { get; set; } = new();
        public ObservableCollection<Item> ItemsPerCategory { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();
        
        // Collections for the Order and the order items 
        public ObservableCollection<CartItem> CartItems { get; set; } = new();
        public ObservableCollection<Order> Orders { get; set; } = new();

        [ObservableProperty]
        private Table _table;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(ItemsPerCategory))]
        private Category _category;

        [ObservableProperty]
        private Item _item;

        [ObservableProperty]
        private Order _order;

        //executed by toolkit for the observable property "Category"
        partial void OnCategoryChanged(Category? cat)
        {
            InitializeItemProCategory();
        }


        public void InitializeItemProCategory()
        {
            if(Category is not  null )
            {
                ItemsPerCategory.Clear();
                var itCat = _itemService.GetItemForCategory(Category.Id);
                foreach(var ic in itCat)
                {
                    ItemsPerCategory.Add(ic);
                }
            }
        }
        public void Initialize()
        {
            var items = _itemService.GetAllItems();
            var categ =_categoryService.GetAllCategories();
            var cartItems = _cartItemService.GetCartItems();
            var orders = _orderService.GetAllOrders();
           
            foreach(var cat in categ)
                Categories.Add(cat);
            foreach(var it in items)
                Items.Add(it);
            foreach(var cartitem in  cartItems)
                CartItems.Add(cartitem);
            foreach(var order in orders)
                Orders.Add(order);

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
    }
}
