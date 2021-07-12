using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class AddAndInitPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bc784c0-a113-45a1-940f-a39461d443b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c3ff17-a5f3-4075-8b5c-7a801385e490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e68e3a56-44fe-429b-b10a-4955bb1c0700");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64d6df3c-6754-4694-8db1-a6ddf51cae8a", "64f0d668-cdb5-4ea0-8108-358a16f992e1", "Shipper", "SHIPPER" },
                    { "f5383f38-018b-476b-9503-7afef0cc5f58", "7896bc21-6857-41e1-ab09-def47fa66032", "Administrator", "ADMINISTRATOR" },
                    { "433b3c19-0ce8-4ebe-9738-662204985ab0", "714397a4-863b-4e65-aa42-3278d5da5f74", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Price",
                value: 3500m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Price",
                value: 7000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "433b3c19-0ce8-4ebe-9738-662204985ab0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64d6df3c-6754-4694-8db1-a6ddf51cae8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5383f38-018b-476b-9503-7afef0cc5f58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e68e3a56-44fe-429b-b10a-4955bb1c0700", "8192f3b4-812f-475e-b560-a51067db041c", "Shipper", "SHIPPER" },
                    { "1bc784c0-a113-45a1-940f-a39461d443b5", "34ac782e-f18a-4258-8c7c-fe1eb7ca0a28", "Administrator", "ADMINISTRATOR" },
                    { "d1c3ff17-a5f3-4075-8b5c-7a801385e490", "bb64cf76-2c4f-4a24-bd64-5ce83baebe81", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Price",
                value: 0m);
        }
    }
}
