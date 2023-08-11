using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 1, "Credit Card Loans", "Credit Card" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "Food", "Food" });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpenseId", "CategoryId", "DatePurchased", "Item", "ItemAmount" },
                values: new object[] { 1, 1, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Camera", 55790.00m });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpenseId", "CategoryId", "DatePurchased", "Item", "ItemAmount" },
                values: new object[] { 2, 2, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coffee", 250m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "ExpenseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
