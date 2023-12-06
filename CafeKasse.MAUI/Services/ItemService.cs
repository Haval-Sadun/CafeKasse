using CafeKasse.MAUI.Models;
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
            new Item(){ Id =1, Name="Espresso", Image="espresso.jpg" , Description="random description for the Item",Price=2.4, CategoryId=1, CategoryName = "Hot Beverages"},
            new Item(){ Id =2, Name="Cappuccino", Image="cappuccino.jpg" , Description="random description for the Item",Price=2.4, CategoryId=1 ,CategoryName = "Hot Beverages"},
            new Item(){ Id =3, Name="Latte", Image="latte.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=1,CategoryName = "Hot Beverages"},
            new Item(){ Id =4, Name="Americano", Image="americano.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=1, CategoryName = "Hot Beverages"},
            new Item(){ Id =5, Name="Mocha", Image="mocha.png" , Description="random description for the Item", Price = 2.4, CategoryId=1, CategoryName = "Hot Beverages"},
            new Item(){ Id =6, Name="Iced Coffee", Image="iced_coffee.jpg" , Description="random description for the Item", Price=2.4, CategoryId=2 ,CategoryName = "Cold Beverages"},
            new Item(){ Id =7, Name="Cold Brew", Image="cold_brew.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =8, Name="Iced Latte", Image="iced_latte.jpeg" , Description="random description for the Item", Price = 2.4, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =9, Name="Frappuccino", Image="frappuccino.jpg" , Description="random description for the Item",Price=2.40, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =10, Name="Smoothie", Image="smoothie.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=2,CategoryName = "Cold Beverages"},
            new Item(){ Id =11, Name="Croissant", Image="croissant.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =12, Name="Chocolate Danish", Image="chocolate_danish.jpg" , Description="random description for the Item",Price=2.4, CategoryId=3 ,CategoryName = "Pastries"},
            new Item(){ Id =13, Name="Blueberry Muffin", Image="blueberry_muffin.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =14, Name="Almond Croissant", Image="almond_croissant.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =15, Name="Cinnamon Roll", Image="cinnamon_roll.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=3,CategoryName = "Pastries"},
            new Item(){ Id =16, Name="Turkey Club Sandwich", Image="turkey_club_sandwich.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =17, Name="Caprese Panini", Image="caprese_panini.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =18, Name="Chicken Caesar Wrap", Image="chicken_caesar_wrap.jpg" , Description="random description for the Item",  Price=2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =19, Name="Veggie Delight Sandwich", Image="veggie_delight_sandwich.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =20, Name="BLT (Bacon, Lettuce, Tomato)", Image="blt.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=4,CategoryName = "Sandwiches"},
            new Item(){ Id =21, Name="Chocolate Cake", Image="chocolate_cake.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =22, Name="Cheesecake (New York Style)", Image="cheesecake.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =23, Name="Tiramisu", Image="tiramisu.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =24, Name="Apple Pie", Image="apple_pie.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
            new Item(){ Id =25, Name="Ice Cream Sundae", Image="ice_cream_sundae.jpg" , Description="random description for the Item", Price = 2.4, CategoryId=5,CategoryName = "Desserts"},
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
