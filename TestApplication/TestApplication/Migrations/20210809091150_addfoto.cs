using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class addfoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3069ae5-a85f-48a0-a7e8-90da22c138d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5c31c7a-27b6-4560-a8a8-8d196d931633");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e271794e-d1ce-402e-898c-89500ac3c1da");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e07ac8fb-b181-44fa-892b-dde8acec3403", "79eca0be-ae69-4387-8e67-45419be30f21", "Shipper", "SHIPPER" },
                    { "d592dc3d-1182-49d3-8288-cfd2a546aa5c", "a77a5b2d-1b1d-4d89-80c0-ab8ac013eadd", "Administrator", "ADMINISTRATOR" },
                    { "89dfa977-61f4-4452-94b1-ccbdd27409a3", "af90dfa1-bbc6-462e-8ff3-9e67cc14adcc", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Foto",
                value: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Foto",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5c31c7a-27b6-4560-a8a8-8d196d931633", "b70d687f-f325-44c1-a4d9-d24b00623843", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e271794e-d1ce-402e-898c-89500ac3c1da", "614e869e-f94b-4bd9-9208-873566b78f99", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3069ae5-a85f-48a0-a7e8-90da22c138d0", "29cbdd9b-f380-427e-a0d8-d87924696b82", "User", "USER" });
        }
    }
}
