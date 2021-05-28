using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "Pandi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "Lot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "GoDown",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "Agents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                schema: "dbo",
                table: "Adda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "Pandi");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "Lot");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "City");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "EDate",
                schema: "dbo",
                table: "Adda");
        }
    }
}
