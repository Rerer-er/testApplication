using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class newDatabeseAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12bafe9f-71bf-416d-8d5b-4d8d971c8ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3033b6db-7e64-4acf-8c75-4915db4a44e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0423833-f775-4a55-9244-9b9c801aaac8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c96d298-a63a-44cf-8b45-a412c75dc051", "d9cea76b-3310-4a14-8617-69d53bc9716a", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c54c564c-782b-4b6e-817f-6367bedb9e63", "cffcef99-2cc9-4869-ba90-8536c2dd31b9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b258e51-2eb9-4d26-97b7-7dfb9cc0e836", "052530a3-5338-4c0f-919d-79744cd8117c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b258e51-2eb9-4d26-97b7-7dfb9cc0e836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c96d298-a63a-44cf-8b45-a412c75dc051");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c54c564c-782b-4b6e-817f-6367bedb9e63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12bafe9f-71bf-416d-8d5b-4d8d971c8ee7", "8d76927a-afad-4462-a904-0d04e2b5ec8e", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3033b6db-7e64-4acf-8c75-4915db4a44e8", "bc48cccf-96df-4150-ac8f-d39bbe6c1749", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0423833-f775-4a55-9244-9b9c801aaac8", "4b872010-1543-4b3b-8738-3b84185dd9aa", "User", "USER" });
        }
    }
}
