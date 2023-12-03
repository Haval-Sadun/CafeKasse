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
        public CategoryViewModel(CategoryService categoryService, ItemService itemService)
        {
            _categoryService = categoryService;
            _itemService = itemService;

        }

        public ObservableCollection<Item> Items { get; set; } = new();
        public ObservableCollection<Item> ItemsPerCategory { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();
        
        [ObservableProperty]
        private Table _table;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(ItemsPerCategory))]
        private Category _category;

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
           
            foreach(var cat in categ)
            {
                Categories.Add(cat);
            }
            foreach(var it in items)
            {
                Items.Add(it);
            }

        }

        [RelayCommand]
        private void SelectedCategory_Changed(Category category)
        {
            Category = category;
            InitializeItemProCategory();
            //Toast.Make("Category has been attached" + category.Name, ToastDuration.Long,30).Show();
        }
    }
}
