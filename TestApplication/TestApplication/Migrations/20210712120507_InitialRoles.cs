using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class InitialRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01679260-3738-4c47-9065-d0273ba10337");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "794f777a-e1b4-4017-a266-27ca909a461e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01679260-3738-4c47-9065-d0273ba10337", "90335096-53f3-4532-ab3e-53bc464816c8", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "794f777a-e1b4-4017-a266-27ca909a461e", "68f9bed5-8f1f-4ee7-a629-dc9232cbac33", "Administrator", "ADMINISTRATOR" });
        }
    }
}
