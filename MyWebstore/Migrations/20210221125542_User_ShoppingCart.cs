using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebstore.Migrations
{
    public partial class User_ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ShoppingCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ShoppingCart_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_ShoppingCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ShoppingCart_ShoppingCartId",
                table: "User_ShoppingCart",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ShoppingCart_UserId",
                table: "User_ShoppingCart",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_ShoppingCart");
        }
    }
}
