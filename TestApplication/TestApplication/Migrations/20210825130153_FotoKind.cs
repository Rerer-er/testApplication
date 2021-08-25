using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class FotoKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6220fc5e-be74-4d2c-b47e-d1d573152879");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8462f356-4b01-4547-abb7-01b8328912a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3fba386-5fe2-4c30-819e-52c7cd5de714");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3fba386-5fe2-4c30-819e-52c7cd5de714", "a7e86ed4-f6b5-4e2d-b81c-42cec237712c", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8462f356-4b01-4547-abb7-01b8328912a8", "29864154-88cd-47eb-9063-8f93e0f9dbb5", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6220fc5e-be74-4d2c-b47e-d1d573152879", "a523f46c-0d0f-4ba7-828e-fe65baf7e9ea", "User", "USER" });
        }
    }
}
