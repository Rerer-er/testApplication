using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "433b3c19-0ce8-4ebe-9738-662204985ab0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64d6df3c-6754-4694-8db1-a6ddf51cae8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5383f38-018b-476b-9503-7afef0cc5f58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acedfe50-e5a0-40e5-bb17-44a92317dc40", "81f62316-7361-41bc-916b-913707584b76", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd2cf624-712b-4885-8758-4e013cb2b878", "7a22dfd7-cd44-46d5-a56f-46b7771b6eb9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a13715f6-b929-4747-b1fc-a60021395445", "5fe2a832-22c5-4b73-b264-d0a685378f4c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a13715f6-b929-4747-b1fc-a60021395445");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acedfe50-e5a0-40e5-bb17-44a92317dc40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd2cf624-712b-4885-8758-4e013cb2b878");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64d6df3c-6754-4694-8db1-a6ddf51cae8a", "64f0d668-cdb5-4ea0-8108-358a16f992e1", "Shipper", "SHIPPER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5383f38-018b-476b-9503-7afef0cc5f58", "7896bc21-6857-41e1-ab09-def47fa66032", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "433b3c19-0ce8-4ebe-9738-662204985ab0", "714397a4-863b-4e65-aa42-3278d5da5f74", "User", "USER" });
        }
    }
}
