using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class SeedClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Client1", false },
                    { 2, "Client2", false },
                    { 3, "Client3", false },
                    { 4, "Client4", true },
                    { 5, "Client5", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
