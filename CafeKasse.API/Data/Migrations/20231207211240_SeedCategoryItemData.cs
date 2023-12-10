using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeKasse.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryItemData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "hot_beverages.jpg", "Hot Beverages" },
                    { 2, "cold_beverages.jpg", "Cold Beverages" },
                    { 3, "pastries.jpg", "Pastries" },
                    { 4, "sandwiches.jpg", "Sandwiches" },
                    { 5, "desserts.jpg", "Desserts" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "random description for the Item", "espresso.jpg", "Espresso", 2.3999999999999999 },
                    { 2, 1, "random description for the Item", "cappuccino.jpg", "Cappuccino", 2.3999999999999999 },
                    { 3, 1, "random description for the Item", "latte.jpg", "Latte", 2.3999999999999999 },
                    { 4, 1, "random description for the Item", "americano.jpg", "Americano", 2.3999999999999999 },
                    { 5, 1, "random description for the Item", "mocha.png", "Mocha", 2.3999999999999999 },
                    { 6, 2, "random description for the Item", "iced_coffee.jpg", "Iced Coffee", 2.3999999999999999 },
                    { 7, 2, "random description for the Item", "cold_brew.jpg", "Cold Brew", 2.3999999999999999 },
                    { 8, 2, "random description for the Item", "iced_latte.jpeg", "Iced Latte", 2.3999999999999999 },
                    { 9, 2, "random description for the Item", "frappuccino.jpg", "Frappuccino", 2.3999999999999999 },
                    { 10, 2, "random description for the Item", "smoothie.jpg", "Smoothie", 2.3999999999999999 },
                    { 11, 3, "random description for the Item", "croissant.jpg", "Croissant", 2.3999999999999999 },
                    { 12, 3, "random description for the Item", "chocolate_danish.jpg", "Chocolate Danish", 2.3999999999999999 },
                    { 13, 3, "random description for the Item", "blueberry_muffin.jpg", "Blueberry Muffin", 2.3999999999999999 },
                    { 14, 3, "random description for the Item", "almond_croissant.jpg", "Almond Croissant", 2.3999999999999999 },
                    { 15, 3, "random description for the Item", "cinnamon_roll.jpg", "Cinnamon Roll", 2.3999999999999999 },
                    { 16, 4, "random description for the Item", "turkey_club_sandwich.jpg", "Turkey Club Sandwich", 2.3999999999999999 },
                    { 17, 4, "random description for the Item", "caprese_panini.jpg", "Caprese Panini", 2.3999999999999999 },
                    { 18, 4, "random description for the Item", "chicken_caesar_wrap.jpg", "Chicken Caesar Wrap", 2.3999999999999999 },
                    { 19, 4, "random description for the Item", "veggie_delight_sandwich.jpg", "Veggie Delight Sandwich", 2.3999999999999999 },
                    { 20, 4, "random description for the Item", "blt.jpg", "BLT (Bacon, Lettuce, Tomato)", 2.3999999999999999 },
                    { 21, 5, "random description for the Item", "chocolate_cake.jpg", "Chocolate Cake", 2.3999999999999999 },
                    { 22, 5, "random description for the Item", "cheesecake.jpg", "Cheesecake (New York Style)", 2.3999999999999999 },
                    { 23, 5, "random description for the Item", "tiramisu.jpg", "Tiramisu", 2.3999999999999999 },
                    { 24, 5, "random description for the Item", "apple_pie.jpg", "Apple Pie", 2.3999999999999999 },
                    { 25, 5, "random description for the Item", "ice_cream_sundae.jpg", "Ice Cream Sundae", 2.3999999999999999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
