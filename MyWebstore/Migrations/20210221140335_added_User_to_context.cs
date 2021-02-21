using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebstore.Migrations
{
    public partial class added_User_to_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_StoreItem_StoreItemId",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ShoppingCart_ShoppingCart_ShoppingCartId",
                table: "User_ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ShoppingCart_AspNetUsers_UserId",
                table: "User_ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_ShoppingCart",
                table: "User_ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreItem",
                table: "StoreItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "User_ShoppingCart",
                newName: "Users_ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "StoreItem",
                newName: "StoreItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameIndex(
                name: "IX_User_ShoppingCart_UserId",
                table: "Users_ShoppingCarts",
                newName: "IX_Users_ShoppingCarts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_ShoppingCart_ShoppingCartId",
                table: "Users_ShoppingCarts",
                newName: "IX_Users_ShoppingCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_StoreItemId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_StoreItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users_ShoppingCarts",
                table: "Users_ShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreItems",
                table: "StoreItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_StoreItems_StoreItemId",
                table: "ShoppingCarts",
                column: "StoreItemId",
                principalTable: "StoreItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "Users_ShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ShoppingCarts_AspNetUsers_UserId",
                table: "Users_ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_StoreItems_StoreItemId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "Users_ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ShoppingCarts_AspNetUsers_UserId",
                table: "Users_ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users_ShoppingCarts",
                table: "Users_ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreItems",
                table: "StoreItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "Users_ShoppingCarts",
                newName: "User_ShoppingCart");

            migrationBuilder.RenameTable(
                name: "StoreItems",
                newName: "StoreItem");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ShoppingCarts_UserId",
                table: "User_ShoppingCart",
                newName: "IX_User_ShoppingCart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ShoppingCarts_ShoppingCartId",
                table: "User_ShoppingCart",
                newName: "IX_User_ShoppingCart_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_StoreItemId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_StoreItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_ShoppingCart",
                table: "User_ShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreItem",
                table: "StoreItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_StoreItem_StoreItemId",
                table: "ShoppingCart",
                column: "StoreItemId",
                principalTable: "StoreItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ShoppingCart_ShoppingCart_ShoppingCartId",
                table: "User_ShoppingCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ShoppingCart_AspNetUsers_UserId",
                table: "User_ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
