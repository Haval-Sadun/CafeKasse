using CafeKasse.API.Models;
using CafeKasse.API.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace CafeKasse.API.Data
{
    public class CafeContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CafeConStr"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region configuring the tables
            // Configure The Category Table
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired();

            // Configure The Item Table
            modelBuilder.Entity<Item>().ToTable("Items");

            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);

            // Configure The Table Table
            modelBuilder.Entity<Table>().ToTable("Tables");

            modelBuilder.Entity<Table>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Table>()
                .Property(t => t.TableNumber)
                .IsRequired();

            //  Configure The Order Table
            modelBuilder.Entity<Order>().ToTable("Orders");

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(it => it.Order)
                .HasForeignKey(it => it.OrderId)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableId);

            //  Configure The OrderItem Table
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");

            modelBuilder.Entity<OrderItem>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithOne(i => i.OrderItem)
                .HasForeignKey<OrderItem>(x => x.ItemId)
                .IsRequired();
            modelBuilder.Entity<OrderItem>()
                .HasIndex(oi => oi.ItemId)
                .IsUnique(false);
            #endregion

            #region Seeding Data 
            modelBuilder.Entity<Table>().HasData(
                new Table { Id = 1, TableNumber = 1, State = TableStatus.Available },
                new Table { Id = 2, TableNumber = 2, State = TableStatus.Resevered },
                new Table { Id = 3, TableNumber = 3, State = TableStatus.Occupied },
                new Table { Id = 4, TableNumber = 4, State = TableStatus.Resevered },
                new Table { Id = 5, TableNumber = 5, State = TableStatus.Resevered },
                new Table { Id = 6, TableNumber = 6, State = TableStatus.Resevered },
                new Table { Id = 7, TableNumber = 7, State = TableStatus.Resevered },
                new Table { Id = 8, TableNumber = 8, State = TableStatus.Resevered },
                new Table { Id = 9, TableNumber = 9, State = TableStatus.Resevered },
                new Table { Id = 10, TableNumber = 10, State = TableStatus.Resevered },
                new Table { Id = 11, TableNumber = 11, State = TableStatus.Available },
                new Table { Id = 12, TableNumber = 12, State = TableStatus.Resevered },
                new Table { Id = 13, TableNumber = 13, State = TableStatus.Occupied },
                new Table { Id = 14, TableNumber = 14, State = TableStatus.Resevered },
                new Table { Id = 15, TableNumber = 15, State = TableStatus.Resevered }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Hot Beverages", Image = "hot_beverages.jpg" },
                new Category() { Id = 2, Name = "Cold Beverages", Image = "cold_beverages.jpg" },
                new Category() { Id = 3, Name = "Pastries", Image = "pastries.jpg" },
                new Category() { Id = 4, Name = "Sandwiches", Image = "sandwiches.jpg" },
                new Category() { Id = 5, Name = "Desserts", Image = "desserts.jpg" }
                );

            modelBuilder.Entity<Item>().HasData(
                new Item() { Id = 1, Name = "Espresso", Image = "espresso.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 1 },
                new Item() { Id = 2, Name = "Cappuccino", Image = "cappuccino.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 1 },
                new Item() { Id = 3, Name = "Latte", Image = "latte.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 1 },
                new Item() { Id = 4, Name = "Americano", Image = "americano.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 1 },
                new Item() { Id = 5, Name = "Mocha", Image = "mocha.png", Description = "random description for the Item", Price = 2.4, CategoryId = 1 },
                new Item() { Id = 6, Name = "Iced Coffee", Image = "iced_coffee.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 2 },
                new Item() { Id = 7, Name = "Cold Brew", Image = "cold_brew.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 2 },
                new Item() { Id = 8, Name = "Iced Latte", Image = "iced_latte.jpeg", Description = "random description for the Item", Price = 2.4, CategoryId = 2 },
                new Item() { Id = 9, Name = "Frappuccino", Image = "frappuccino.jpg", Description = "random description for the Item", Price = 2.40, CategoryId = 2 },
                new Item() { Id = 10, Name = "Smoothie", Image = "smoothie.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 2 },
                new Item() { Id = 11, Name = "Croissant", Image = "croissant.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 3 },
                new Item() { Id = 12, Name = "Chocolate Danish", Image = "chocolate_danish.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 3 },
                new Item() { Id = 13, Name = "Blueberry Muffin", Image = "blueberry_muffin.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 3 },
                new Item() { Id = 14, Name = "Almond Croissant", Image = "almond_croissant.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 3 },
                new Item() { Id = 15, Name = "Cinnamon Roll", Image = "cinnamon_roll.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 3 },
                new Item() { Id = 16, Name = "Turkey Club Sandwich", Image = "turkey_club_sandwich.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 4 },
                new Item() { Id = 17, Name = "Caprese Panini", Image = "caprese_panini.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 4 },
                new Item() { Id = 18, Name = "Chicken Caesar Wrap", Image = "chicken_caesar_wrap.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 4 },
                new Item() { Id = 19, Name = "Veggie Delight Sandwich", Image = "veggie_delight_sandwich.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 4 },
                new Item() { Id = 20, Name = "BLT (Bacon, Lettuce, Tomato)", Image = "blt.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 4 },
                new Item() { Id = 21, Name = "Chocolate Cake", Image = "chocolate_cake.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 5 },
                new Item() { Id = 22, Name = "Cheesecake (New York Style)", Image = "cheesecake.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 5 },
                new Item() { Id = 23, Name = "Tiramisu", Image = "tiramisu.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 5 },
                new Item() { Id = 24, Name = "Apple Pie", Image = "apple_pie.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 5 },
                new Item() { Id = 25, Name = "Ice Cream Sundae", Image = "ice_cream_sundae.jpg", Description = "random description for the Item", Price = 2.4, CategoryId = 5 }
                );

            #endregion
        }


    }
}
