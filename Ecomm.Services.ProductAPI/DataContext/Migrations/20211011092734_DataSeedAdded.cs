using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecomm.Services.ProductAPI.DataContext.Migrations
{
    public partial class DataSeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Appetizer", "Greatest pide of all time", "", "Pide", 10.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
