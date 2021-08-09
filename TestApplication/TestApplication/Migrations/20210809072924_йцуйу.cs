using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class йцуйу : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c467161-51ba-4b39-8b91-a0804fa17b09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "722fe4de-91e2-4ccc-8c71-ca22c6a86c42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab7ad6fa-f770-424b-acc2-1676d5d6a454");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c467161-51ba-4b39-8b91-a0804fa17b09", "a29c79e3-7bfc-46f8-86a7-70864ec62bf6", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab7ad6fa-f770-424b-acc2-1676d5d6a454", "e9a77c6a-23de-4e9a-a7ed-ef8be3e81f0d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "722fe4de-91e2-4ccc-8c71-ca22c6a86c42", "0fbf932c-a00b-43b6-ba2b-0b3c6fcca8a2", "User", "USER" });
        }
    }
}
