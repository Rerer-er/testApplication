using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class Basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89dfa977-61f4-4452-94b1-ccbdd27409a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d592dc3d-1182-49d3-8288-cfd2a546aa5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e07ac8fb-b181-44fa-892b-dde8acec3403");

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    ProductBasketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.ProductBasketId);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baskets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c205939-61da-4c82-80c7-0dbea3391ee9", "6bb66055-ae26-49e2-a5a7-e0c0fe7e62e7", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e4ccda0-9097-4b2d-bf84-a4f5e5846bae", "cba8b154-d1b8-462c-9678-65b28e0493b2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d9ffe31-b617-45d1-a656-7d6566fe1de1", "6ad9027e-c2c3-4488-81dd-c30532a14bbf", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d9ffe31-b617-45d1-a656-7d6566fe1de1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e4ccda0-9097-4b2d-bf84-a4f5e5846bae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c205939-61da-4c82-80c7-0dbea3391ee9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e07ac8fb-b181-44fa-892b-dde8acec3403", "79eca0be-ae69-4387-8e67-45419be30f21", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d592dc3d-1182-49d3-8288-cfd2a546aa5c", "a77a5b2d-1b1d-4d89-80c0-ab8ac013eadd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89dfa977-61f4-4452-94b1-ccbdd27409a3", "af90dfa1-bbc6-462e-8ff3-9e67cc14adcc", "User", "USER" });
        }
    }
}
