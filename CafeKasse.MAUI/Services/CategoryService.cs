using CafeKasse.MAUI.Entities;
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
            new Category() { Id= 1, Name= "Hot Beverages" },
            new Category() { Id= 2, Name= "Cold Beverages" },
            new Category() { Id= 3, Name= "Pastries" },
            new Category() { Id= 4, Name= "Sandwiches" },
            new Category() { Id= 5, Name= "Desserts" },
         };

        public IEnumerable<Category> GetAllCategories() => _categories;
    }
}

