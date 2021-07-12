using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class AddPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ee849f9-91ed-450c-b029-250e81e22572");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3221d2e-1e87-43d7-a96e-ea47f509efa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8851f15-7a69-4985-8358-0724169374a3");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e68e3a56-44fe-429b-b10a-4955bb1c0700", "8192f3b4-812f-475e-b560-a51067db041c", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bc784c0-a113-45a1-940f-a39461d443b5", "34ac782e-f18a-4258-8c7c-fe1eb7ca0a28", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1c3ff17-a5f3-4075-8b5c-7a801385e490", "bb64cf76-2c4f-4a24-bd64-5ce83baebe81", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ee849f9-91ed-450c-b029-250e81e22572", "795b42e3-0bcf-43a4-8bd1-8f9a0a1e0c42", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8851f15-7a69-4985-8358-0724169374a3", "fbdbfe57-01ee-465c-a9c9-7e1bdace11a1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3221d2e-1e87-43d7-a96e-ea47f509efa4", "9201c50e-a853-407a-8ab0-51d405410451", "User", "USER" });
        }
    }
}
