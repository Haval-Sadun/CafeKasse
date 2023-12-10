﻿// <auto-generated />
using System;
using CafeKasse.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeKasse.API.Data.Migrations
{
    [DbContext(typeof(CafeContext))]
    partial class CafeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CafeKasse.API.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "hot_beverages.jpg",
                            Name = "Hot Beverages"
                        },
                        new
                        {
                            Id = 2,
                            Image = "cold_beverages.jpg",
                            Name = "Cold Beverages"
                        },
                        new
                        {
                            Id = 3,
                            Image = "pastries.jpg",
                            Name = "Pastries"
                        },
                        new
                        {
                            Id = 4,
                            Image = "sandwiches.jpg",
                            Name = "Sandwiches"
                        },
                        new
                        {
                            Id = 5,
                            Image = "desserts.jpg",
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("CafeKasse.API.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "random description for the Item",
                            Image = "espresso.jpg",
                            Name = "Espresso",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "random description for the Item",
                            Image = "cappuccino.jpg",
                            Name = "Cappuccino",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "random description for the Item",
                            Image = "latte.jpg",
                            Name = "Latte",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "random description for the Item",
                            Image = "americano.jpg",
                            Name = "Americano",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "random description for the Item",
                            Image = "mocha.png",
                            Name = "Mocha",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "random description for the Item",
                            Image = "iced_coffee.jpg",
                            Name = "Iced Coffee",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "random description for the Item",
                            Image = "cold_brew.jpg",
                            Name = "Cold Brew",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Description = "random description for the Item",
                            Image = "iced_latte.jpeg",
                            Name = "Iced Latte",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Description = "random description for the Item",
                            Image = "frappuccino.jpg",
                            Name = "Frappuccino",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Description = "random description for the Item",
                            Image = "smoothie.jpg",
                            Name = "Smoothie",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Description = "random description for the Item",
                            Image = "croissant.jpg",
                            Name = "Croissant",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Description = "random description for the Item",
                            Image = "chocolate_danish.jpg",
                            Name = "Chocolate Danish",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Description = "random description for the Item",
                            Image = "blueberry_muffin.jpg",
                            Name = "Blueberry Muffin",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            Description = "random description for the Item",
                            Image = "almond_croissant.jpg",
                            Name = "Almond Croissant",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Description = "random description for the Item",
                            Image = "cinnamon_roll.jpg",
                            Name = "Cinnamon Roll",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Description = "random description for the Item",
                            Image = "turkey_club_sandwich.jpg",
                            Name = "Turkey Club Sandwich",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Description = "random description for the Item",
                            Image = "caprese_panini.jpg",
                            Name = "Caprese Panini",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Description = "random description for the Item",
                            Image = "chicken_caesar_wrap.jpg",
                            Name = "Chicken Caesar Wrap",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Description = "random description for the Item",
                            Image = "veggie_delight_sandwich.jpg",
                            Name = "Veggie Delight Sandwich",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Description = "random description for the Item",
                            Image = "blt.jpg",
                            Name = "BLT (Bacon, Lettuce, Tomato)",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 5,
                            Description = "random description for the Item",
                            Image = "chocolate_cake.jpg",
                            Name = "Chocolate Cake",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 5,
                            Description = "random description for the Item",
                            Image = "cheesecake.jpg",
                            Name = "Cheesecake (New York Style)",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 5,
                            Description = "random description for the Item",
                            Image = "tiramisu.jpg",
                            Name = "Tiramisu",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 5,
                            Description = "random description for the Item",
                            Image = "apple_pie.jpg",
                            Name = "Apple Pie",
                            Price = 2.3999999999999999
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 5,
                            Description = "random description for the Item",
                            Image = "ice_cream_sundae.jpg",
                            Name = "Ice Cream Sundae",
                            Price = 2.3999999999999999
                        });
                });

            modelBuilder.Entity("CafeKasse.API.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("CafeKasse.API.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("CafeKasse.API.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            State = 2,
                            TableNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            State = 1,
                            TableNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            State = 3,
                            TableNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            State = 1,
                            TableNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            State = 1,
                            TableNumber = 5
                        },
                        new
                        {
                            Id = 6,
                            State = 1,
                            TableNumber = 6
                        },
                        new
                        {
                            Id = 7,
                            State = 1,
                            TableNumber = 7
                        },
                        new
                        {
                            Id = 8,
                            State = 1,
                            TableNumber = 8
                        },
                        new
                        {
                            Id = 9,
                            State = 1,
                            TableNumber = 9
                        },
                        new
                        {
                            Id = 10,
                            State = 1,
                            TableNumber = 10
                        },
                        new
                        {
                            Id = 11,
                            State = 2,
                            TableNumber = 11
                        },
                        new
                        {
                            Id = 12,
                            State = 1,
                            TableNumber = 12
                        },
                        new
                        {
                            Id = 13,
                            State = 3,
                            TableNumber = 13
                        },
                        new
                        {
                            Id = 14,
                            State = 1,
                            TableNumber = 14
                        },
                        new
                        {
                            Id = 15,
                            State = 1,
                            TableNumber = 15
                        });
                });

            modelBuilder.Entity("CafeKasse.API.Models.Item", b =>
                {
                    b.HasOne("CafeKasse.API.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CafeKasse.API.Models.Order", b =>
                {
                    b.HasOne("CafeKasse.API.Models.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("CafeKasse.API.Models.OrderItem", b =>
                {
                    b.HasOne("CafeKasse.API.Models.Item", "Item")
                        .WithOne("OrderItem")
                        .HasForeignKey("CafeKasse.API.Models.OrderItem", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeKasse.API.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CafeKasse.API.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CafeKasse.API.Models.Item", b =>
                {
                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("CafeKasse.API.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("CafeKasse.API.Models.Table", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
