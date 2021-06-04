using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addLedger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ledger",
                schema: "dbo",
                columns: table => new
                {
                    SAccName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAccNameU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LG_Narat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LG_NaratU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LG_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LGID = table.Column<float>(type: "real", nullable: false),
                    Dr = table.Column<float>(type: "real", nullable: false),
                    Cr = table.Column<float>(type: "real", nullable: false),
                    Acc_code = table.Column<int>(type: "int", nullable: false),
                    branchid = table.Column<int>(type: "int", nullable: false),
                    packetqty = table.Column<float>(type: "real", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    LG_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisRs = table.Column<float>(type: "real", nullable: false),
                    DisPer = table.Column<float>(type: "real", nullable: false),
                    chqno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SID = table.Column<float>(type: "real", nullable: false),
                    OperatorID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledger",
                schema: "dbo");
        }
    }
}
