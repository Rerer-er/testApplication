using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class ShipperStars1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ae6684d-8c80-4f3b-953f-78d01251cd5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93cbefa6-d147-46e2-a56b-f5afe4b64271");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baae3b7a-db08-4ac3-a625-dd7baefb30e1");

            migrationBuilder.DropColumn(
                name: "CountRating",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "FinalRating",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "SumRating",
                table: "Shippers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2521644-fa75-4bd1-86ee-78ea55ea6acc", "92c8d087-d656-44ca-8993-d5a75520e291", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "753280fb-3c72-4169-acb5-ca4f7a591691", "77714603-3adb-46c5-b143-779d33772b8d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d421435-120c-4a51-a06b-dce9bb76c347", "160c0293-583b-4830-9500-3a6600bda3fc", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d421435-120c-4a51-a06b-dce9bb76c347");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "753280fb-3c72-4169-acb5-ca4f7a591691");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2521644-fa75-4bd1-86ee-78ea55ea6acc");

            migrationBuilder.AddColumn<decimal>(
                name: "CountRating",
                table: "Shippers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalRating",
                table: "Shippers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SumRating",
                table: "Shippers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baae3b7a-db08-4ac3-a625-dd7baefb30e1", "a2dce58c-a72e-4400-b714-040e74fafcab", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ae6684d-8c80-4f3b-953f-78d01251cd5f", "3ea4e447-99c0-4bea-b713-75e7ccfd57aa", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93cbefa6-d147-46e2-a56b-f5afe4b64271", "a750a8aa-1a8e-4ed6-8fa2-16f6540202a2", "User", "USER" });
        }
    }
}
