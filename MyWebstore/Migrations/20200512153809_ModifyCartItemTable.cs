using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebstore.Migrations
{
    public partial class ModifyCartItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "storeItemId",
                table: "CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_storeItemId",
                table: "CartItem",
                column: "storeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_StoreItem_storeItemId",
                table: "CartItem",
                column: "storeItemId",
                principalTable: "StoreItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_StoreItem_storeItemId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_storeItemId",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "storeItemId",
                table: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
