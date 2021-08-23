using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class ShipperStars2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Shippers",
                newName: "SumRating");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CountRating",
                table: "Shippers");

            migrationBuilder.DropColumn(
                name: "FinalRating",
                table: "Shippers");

            migrationBuilder.RenameColumn(
                name: "SumRating",
                table: "Shippers",
                newName: "rating");

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
    }
}
