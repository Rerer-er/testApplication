using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class ShipperStars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00db0367-74dc-480d-b768-4a0ceeab7031");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "326b04d3-c7e8-47e6-84c6-3ed3b4bf46f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bcafdc-bfe7-4ef0-8457-94a9731956d0");

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

            migrationBuilder.AddColumn<decimal>(
                name: "rating",
                table: "Shippers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "baae3b7a-db08-4ac3-a625-dd7baefb30e1", "a2dce58c-a72e-4400-b714-040e74fafcab", "Shipper", "SHIPPER" },
                    { "4ae6684d-8c80-4f3b-953f-78d01251cd5f", "3ea4e447-99c0-4bea-b713-75e7ccfd57aa", "Administrator", "ADMINISTRATOR" },
                    { "93cbefa6-d147-46e2-a56b-f5afe4b64271", "a750a8aa-1a8e-4ed6-8fa2-16f6540202a2", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "ShipperId",
                keyValue: 1,
                column: "CountRating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Shippers",
                keyColumn: "ShipperId",
                keyValue: 2,
                column: "CountRating",
                value: 1m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Shippers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00db0367-74dc-480d-b768-4a0ceeab7031", "14eb7d6a-9a5e-494f-857d-58c1e6f11d05", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2bcafdc-bfe7-4ef0-8457-94a9731956d0", "9391889f-3e03-43e4-bc52-a4985e5e5e4c", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "326b04d3-c7e8-47e6-84c6-3ed3b4bf46f7", "b2d4429d-1f72-4424-bbb4-6edb4c35cfe2", "User", "USER" });
        }
    }
}
