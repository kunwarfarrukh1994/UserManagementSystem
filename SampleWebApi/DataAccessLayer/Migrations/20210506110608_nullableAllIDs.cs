using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class nullableAllIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty");

            migrationBuilder.DropIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "SaleParty",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty");

            migrationBuilder.DropIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown");

            migrationBuilder.DropIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.AlterColumn<float>(
                name: "ID",
                schema: "dbo",
                table: "SaleParty",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "GoDown",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleParty_ID",
                schema: "dbo",
                table: "SaleParty",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoDown_ID",
                schema: "dbo",
                table: "GoDown",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CodeCodingMain_ID",
                schema: "dbo",
                table: "CodeCodingMain",
                column: "ID",
                unique: true);
        }
    }
}
