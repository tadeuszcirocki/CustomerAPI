using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerAPI.Migrations
{
    public partial class CustomerAPIModelsCustomerContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1L, new DateTime(1946, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "america.fckyeah@gmail.com", "Donald", "Trump", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2L, new DateTime(1611, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.hewe@gmail.com", "Jan", "Heweliusz", "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2L);
        }
    }
}
