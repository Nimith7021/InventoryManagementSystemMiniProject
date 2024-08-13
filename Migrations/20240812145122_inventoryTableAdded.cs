using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class inventoryTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_InventoryId",
                table: "transactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_InventoryId",
                table: "Suppliers",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryId",
                table: "Products",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_inventories_InventoryId",
                table: "Products",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_inventories_InventoryId",
                table: "Suppliers",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_inventories_InventoryId",
                table: "transactions",
                column: "InventoryId",
                principalTable: "inventories",
                principalColumn: "InventoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_inventories_InventoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_inventories_InventoryId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_inventories_InventoryId",
                table: "transactions");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropIndex(
                name: "IX_transactions_InventoryId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_InventoryId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Products");
        }
    }
}
