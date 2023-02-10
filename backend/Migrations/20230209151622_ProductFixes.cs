using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class ProductFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductNumberOfOrders",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductRating",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductUrl",
                table: "Products",
                newName: "ProductDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Products",
                newName: "ProductUrl");

            migrationBuilder.AddColumn<int>(
                name: "ProductNumberOfOrders",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ProductRating",
                table: "Products",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
