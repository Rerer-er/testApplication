using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class Basket4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1815f59b-671e-4148-8998-51db47822b14", "0c4ab768-c5ae-4305-a11f-00adea49e7a3", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62aef7e7-e375-439e-84c9-315248cc72bc", "f582f54f-2c7e-458a-a70c-242da6e57350", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d0e8cf7-33c1-415b-9d19-d8488cce199e", "9ceb8a8f-8a95-4c6c-8cc0-f179c5584474", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1815f59b-671e-4148-8998-51db47822b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d0e8cf7-33c1-415b-9d19-d8488cce199e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62aef7e7-e375-439e-84c9-315248cc72bc");

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
    }
}
