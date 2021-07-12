using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kinds",
                columns: new[] { "KindId", "About", "Name" },
                values: new object[,]
                {
                    { 1, "about food1", "food1" },
                    { 2, "about food2", "food2" }
                });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "ShipperId", "Name" },
                values: new object[,]
                {
                    { 1, "shipper1" },
                    { 2, "shipper2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "KindId", "Name", "ShipperId" },
                values: new object[] { 1, 1, "product", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "KindId", "Name", "ShipperId" },
                values: new object[] { 2, 2, "product", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "KindId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "KindId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shippers",
                keyColumn: "ShipperId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shippers",
                keyColumn: "ShipperId",
                keyValue: 2);
        }
    }
}
