using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebstore.Migrations
{
    public partial class ShoppingCart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreItemId",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_StoreItemId",
                table: "ShoppingCart",
                column: "StoreItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_StoreItem_StoreItemId",
                table: "ShoppingCart",
                column: "StoreItemId",
                principalTable: "StoreItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_StoreItem_StoreItemId",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_StoreItemId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "StoreItemId",
                table: "ShoppingCart");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: true),
                    StoreItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_StoreItem_StoreItemId",
                        column: x => x.StoreItemId,
                        principalTable: "StoreItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartId",
                table: "CartItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_StoreItemId",
                table: "CartItem",
                column: "StoreItemId");
        }
    }
}
