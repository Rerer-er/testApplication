using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class addCountInBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Baskets");

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
    }
}
