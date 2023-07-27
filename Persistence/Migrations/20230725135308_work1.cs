using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class work1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SubjectTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SubjectTimeTables",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "SubjectTimeTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SubjectTimeTables",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubjectTimeTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SubjectTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "SubjectTimeTables",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "LevelTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "LevelTimeTables",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "LevelTimeTables",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "LevelTimeTables",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LevelTimeTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "LevelTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "LevelTimeTables",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "SubjectTimeTables");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LevelTimeTables");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "LevelTimeTables");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "LevelTimeTables");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "LevelTimeTables");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LevelTimeTables");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "LevelTimeTables");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "LevelTimeTables");
        }
    }
}
