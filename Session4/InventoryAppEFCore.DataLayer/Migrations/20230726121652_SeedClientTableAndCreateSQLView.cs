using InventoryAppEFCore.DataLayer.Views;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class SeedClientTableAndCreateSQLView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddViewViaSql<ClientView>("ClientFilterView", "Clients", "Name = 'Client1'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
