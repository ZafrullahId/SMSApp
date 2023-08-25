using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class IsUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReleased",
                table: "StudentsPapers");

            migrationBuilder.AddColumn<bool>(
                name: "IsReleased",
                table: "Papers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReleased",
                table: "Papers");

            migrationBuilder.AddColumn<bool>(
                name: "IsReleased",
                table: "StudentsPapers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
