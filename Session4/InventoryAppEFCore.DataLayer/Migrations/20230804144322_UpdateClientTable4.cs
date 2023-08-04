using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class UpdateClientTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Clients ADD NameAndYearOfBirth AS [Name] + ',' + CONVERT(NVARCHAR, DATEPART(yyyy, [DateOfBirth]))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Clients DROP COLUMN NameAndYearOfBirth");
        }

    }
}
