using CafeKasse.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class CategoryService
    {
       private readonly static IEnumerable<Category> _categories = new List<Category>()
        {
            new Category() { Id= 1, Name= "Hot Beverages", Image="hot_beverages.jpg" },
            new Category() { Id= 2, Name= "Cold Beverages", Image="cold_beverages.jpg" },
            new Category() { Id= 3, Name= "Pastries" , Image = "pastries.jpg"},
            new Category() { Id= 4, Name= "Sandwiches" , Image = "sandwiches.jpg"},
            new Category() { Id= 5, Name= "Desserts" , Image = "desserts.jpg"},
         };

        public IEnumerable<Category> GetAllCategories() => _categories;
    }
}

