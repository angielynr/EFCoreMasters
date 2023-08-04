using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class UpdateClientTable2 : Migration
    {
        /*protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "NameAndYearOfBirth",
            table: "Clients",
            type: "nvarchar(max)",
            nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "Clients",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAndYearOfBirth",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "Clients");
        }*/

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
        name: "BirthYear",
        table: "Clients",
        type: "int",
        nullable: false);
            /*migrationBuilder.AddColumn<string>(
                name: "NameAndYearOfBirth",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ',' + [YearOfBirth]",
                stored: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "Clients",
                type: "int",
                nullable: false,
                computedColumnSql: "DatePart(yyyy, [DateOfBirth])");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "BirthYear",
        table: "Clients");
            /*migrationBuilder.DropColumn(
                name: "NameAndYearOfBirth",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "Clients");*/
        }
        /*protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add a new nullable column to hold computed values temporarily
            migrationBuilder.AddColumn<string>(
                name: "NameAndYearOfBirthTemp",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            // Step 2: Set the initial values for the nullable computed column
            migrationBuilder.Sql("UPDATE [Clients] SET [NameAndYearOfBirthTemp] = [Name] + ',' + CAST(DatePart(yyyy, [DateOfBirth]) AS NVARCHAR(4))");

            // Step 3: Remove the existing computed columns (optional, if you want to remove the previous computed columns)
            migrationBuilder.DropColumn(
                name: "NameAndYearOfBirth",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "Clients");

            // Step 4: Rename the temporary column to the original name
            migrationBuilder.RenameColumn(
                name: "NameAndYearOfBirthTemp",
                table: "Clients",
                newName: "NameAndYearOfBirth");

            // Step 5: Make the new column non-nullable
            migrationBuilder.AlterColumn<string>(
                name: "NameAndYearOfBirth",
                table: "Clients",
                type: "nvarchar(max)", // Or a suitable length depending on your data
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Make the new column nullable again
            migrationBuilder.AlterColumn<string>(
                name: "NameAndYearOfBirth",
                table: "Clients",
                type: "nvarchar(max)", // Or a suitable length depending on your data
                nullable: true);

            // Step 2: Set back the original computed column logic (optional)
            migrationBuilder.AddColumn<string>(
                name: "NameAndYearOfBirth",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ',' + [YearOfBirth]",
                stored: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "Clients",
                type: "int",
                nullable: false,
                computedColumnSql: "DatePart(yyyy, [DateOfBirth])");

            // Step 3: Remove the temporary column
            migrationBuilder.DropColumn(
                name: "NameAndYearOfBirthTemp",
                table: "Clients");
        }*/

    }
}
