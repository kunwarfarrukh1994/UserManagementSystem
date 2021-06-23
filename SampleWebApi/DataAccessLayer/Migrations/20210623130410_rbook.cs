using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class rbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RBookMain",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<float>(type: "real", nullable: false),
                    Cid = table.Column<float>(type: "real", nullable: false),
                    Edate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookSerial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookNo = table.Column<float>(type: "real", nullable: false),
                    SAccId = table.Column<float>(type: "real", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cheques = table.Column<float>(type: "real", nullable: false),
                    Cash = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    T1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N2 = table.Column<float>(type: "real", nullable: false),
                    CompanyID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    OperatorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RBookSub",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaccId = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Narat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PCID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChqBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChqNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChqDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TCRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecAgainst = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChqSr = table.Column<int>(type: "int", nullable: false),
                    ChqNoS = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RBookMain",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RBookSub",
                schema: "dbo");
        }
    }
}
