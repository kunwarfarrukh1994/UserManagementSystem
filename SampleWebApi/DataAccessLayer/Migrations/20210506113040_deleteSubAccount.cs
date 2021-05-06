using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class deleteSubAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_subAccount_ID",
                schema: "dbo",
                table: "subAccount");

            migrationBuilder.RenameTable(
                name: "subAccount",
                schema: "dbo",
                newName: "SubAccount",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "SAccID",
                schema: "dbo",
                table: "SubAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "SubAccount",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "AgentID",
                schema: "dbo",
                table: "SubAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubAccount_ID",
                schema: "dbo",
                table: "SubAccount",
                column: "ID",
                unique: true,
                filter: "[ID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubAccount_ID",
                schema: "dbo",
                table: "SubAccount");

            migrationBuilder.DropColumn(
                name: "AgentID",
                schema: "dbo",
                table: "SubAccount");

            migrationBuilder.RenameTable(
                name: "SubAccount",
                schema: "dbo",
                newName: "subAccount",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<long>(
                name: "SAccID",
                schema: "dbo",
                table: "subAccount",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "dbo",
                table: "subAccount",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subAccount_ID",
                schema: "dbo",
                table: "subAccount",
                column: "ID",
                unique: true);
        }
    }
}
