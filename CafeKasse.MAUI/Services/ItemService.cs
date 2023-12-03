using CafeKasse.MAUI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class ItemService
    {
        private readonly static IEnumerable<Item> _items = new List<Item>()
        {
            new Item(){ Id =1, Name="Espresso", Description="random description for the Item",Price=2.4, CategoryId=1, CategoryName = "Hot Beverages"},
            new Item(){ Id =2, Name="Cappuccino", Description="random description for the Item",Price=2.4, CategoryId=1 ,CategoryName = "Hot Beverages"},
            new Item(){ Id =3, Name="Latte", Description="random description for the Item", Price = 2.4, CategoryId=1,CategoryName = "Hot Beverages"},
            new Item(){ Id =4, Name="Americano", Description="random description for the Item", Price = 2.4, CategoryId=1, CategoryName = "Hot Beverages"},
            new Item(){ Id =5, Name="Mocha", Description="random description for the Item", Price = 2.4, CategoryId=1, CategoryName = "Hot Beverages"},
            new Item(){ Id =6, Name="Iced Coffee", Description="random description for the Item", Price=2.4, CategoryId=2 ,CategoryName = "Cold Beverages"},
            new Item(){ Id =7, Name="Cold Brew", Description="random description for the Item", Price = 2.4, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =8, Name="Iced Latte", Description="random description for the Item", Price = 2.4, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =9, Name="Frappuccino", Description="random description for the Item",Price=2.40, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =10, Name="Smoothie", Description="random description for the Item", Price = 2.4, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =11, Name="Croissant", Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =12, Name="Chocolate Danish", Description="random description for the Item",Price=2.4, CategoryId=3 ,CategoryName = "Pastries"},
            new Item(){ Id =13, Name="Blueberry Muffin", Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =14, Name="Almond Croissant", Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =15, Name="Cinnamon Roll", Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =16, Name="Turkey Club Sandwich", Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =17, Name="Caprese Panini", Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =18, Name="Chicken Caesar Wrap", Description="random description for the Item",  Price=2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =19, Name="Veggie Delight Sandwich", Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =20, Name="BLT (Bacon, Lettuce, Tomato)", Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =21, Name="Chocolate Cake", Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =22, Name="Cheesecake (New York Style)", Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =23, Name="Tiramisu", Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =24, Name="Apple Pie", Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =25, Name="Ice Cream Sundae", Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
        };

        public IEnumerable<Item> GetAllItems() => _items;

        public IEnumerable<Item> GetItemForCategory(int categoryId) 
        {
            if(categoryId != null)
                return _items.Where(i => i.CategoryId == categoryId);
            return _items;
        }

    }
}
