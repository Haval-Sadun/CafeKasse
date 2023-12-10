﻿// <auto-generated />
using System;
using CafeKasse.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeKasse.API.Data.Migrations
{
    [DbContext(typeof(CafeContext))]
    [Migration("20231207210442_SeedTableData")]
    partial class SeedTableData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TableNumber");

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
                        .HasForeignKey("TableNumber")
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
