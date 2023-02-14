using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Prices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShopName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.ShopId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ShopId",
                table: "Prices",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Shop_ShopId",
                table: "Prices",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Shop_ShopId",
                table: "Prices");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Prices_ShopId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Prices");
        }
    }
}
