using CafeKasse.API.Models;
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

            modelBuilder.Entity<Table>()
                .HasMany(t => t.Orders)
                .WithOne(o => o.Table)
                .HasForeignKey(o => o.TableNumber)
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

            //  Configure The OrderItem Table
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");

            modelBuilder.Entity<OrderItem>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithOne(i => i.OrderItem)
                .HasForeignKey<OrderItem>(x => x.ItemId)
                .IsRequired();
        }
    }
}
