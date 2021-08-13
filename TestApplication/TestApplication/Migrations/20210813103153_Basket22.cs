using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class Basket22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "f80b5637-b912-457f-92e8-307bfd1c704e", "ebc0f926-ca0f-42c9-a266-69d3322ca2ad", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e6c0f6a-9064-4315-ba02-f7187b3a0a65", "3cd9fad9-263b-47cc-a9c7-c567cce39242", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d46a9a0-0413-4179-ba52-b0b59138fba9", "4bf6bfe7-0dba-423f-ab67-01e652502468", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d46a9a0-0413-4179-ba52-b0b59138fba9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e6c0f6a-9064-4315-ba02-f7187b3a0a65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f80b5637-b912-457f-92e8-307bfd1c704e");

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
        }
    }
}
