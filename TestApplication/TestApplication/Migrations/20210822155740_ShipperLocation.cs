using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class ShipperLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ecdaec6-64c3-4c09-a807-703dd9f6c69c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac30a246-bfdf-4c9e-9312-f20a9a38f142");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff6875af-efbb-4916-816f-8cdf4d3af34c");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Shippers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LocationLat",
                table: "Shippers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LocationLng",
                table: "Shippers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "LocationLat",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "LocationLng",
                table: "Shippers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac30a246-bfdf-4c9e-9312-f20a9a38f142", "50153e4a-0e20-4976-8c5e-c6039525f683", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff6875af-efbb-4916-816f-8cdf4d3af34c", "1b7e9903-7495-4486-b571-b4f1f378e6fe", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ecdaec6-64c3-4c09-a807-703dd9f6c69c", "ed11e92f-846a-4a51-94cf-2424849a1800", "User", "USER" });
        }
    }
}
