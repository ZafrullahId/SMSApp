using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class resolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "TimeTables");

            migrationBuilder.AddColumn<string>(
                name: "Seasion",
                table: "TimeTables",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seasion",
                table: "TimeTables");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "TimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
