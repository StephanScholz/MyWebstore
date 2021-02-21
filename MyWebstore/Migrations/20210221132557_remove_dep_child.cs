using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebstore.Migrations
{
    public partial class remove_dep_child : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
