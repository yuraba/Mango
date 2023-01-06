using Microsoft.EntityFrameworkCore.Migrations;

namespace MangoApi.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 4, "Phones", "new phone  from apple", "https://dotnetmastery1110.blob.core.windows.net/mango/2023-01-01%2015.47.08.jpg", "Iphone", 999.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
