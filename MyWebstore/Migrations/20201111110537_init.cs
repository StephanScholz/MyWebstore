using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebstore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_StoreItem_storeItemId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "storeItemId",
                table: "CartItem",
                newName: "StoreItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_storeItemId",
                table: "CartItem",
                newName: "IX_CartItem_StoreItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_StoreItem_StoreItemId",
                table: "CartItem",
                column: "StoreItemId",
                principalTable: "StoreItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_StoreItem_StoreItemId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "StoreItemId",
                table: "CartItem",
                newName: "storeItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_StoreItemId",
                table: "CartItem",
                newName: "IX_CartItem_storeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_StoreItem_storeItemId",
                table: "CartItem",
                column: "storeItemId",
                principalTable: "StoreItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
