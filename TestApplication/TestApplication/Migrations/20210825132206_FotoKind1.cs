using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class FotoKind1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d88e78f-d29f-478b-a45a-9efd391ba1bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df742950-c8cd-419c-b3e6-31c2c0d31908");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9a67a28-8ee1-491c-b661-a208a367f74a");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Kinds",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Kinds");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9a67a28-8ee1-491c-b661-a208a367f74a", "ee8d7e5f-069e-4de9-837b-962e9adbae43", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df742950-c8cd-419c-b3e6-31c2c0d31908", "2e88b322-ee50-4bc3-8e32-c4ba1aba6c27", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d88e78f-d29f-478b-a45a-9efd391ba1bb", "3cc685c8-0476-487b-a412-f7da0df679fe", "User", "USER" });
        }
    }
}
