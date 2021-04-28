using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleMains",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SMID = table.Column<int>(type: "int", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SAccID = table.Column<int>(type: "int", nullable: false),
                    GSale = table.Column<float>(type: "real", nullable: false),
                    SReturn = table.Column<float>(type: "real", nullable: false),
                    DiscountUser = table.Column<float>(type: "real", nullable: false),
                    CashRece = table.Column<float>(type: "real", nullable: false),
                    ChqRece = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeReturn = table.Column<float>(type: "real", nullable: false),
                    BiltyExp = table.Column<float>(type: "real", nullable: false),
                    FreightExp = table.Column<float>(type: "real", nullable: false),
                    OtherExp = table.Column<float>(type: "real", nullable: false),
                    CommissionExp = table.Column<float>(type: "real", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    AgentID2 = table.Column<int>(type: "int", nullable: false),
                    BiltyNo = table.Column<int>(type: "int", nullable: false),
                    Goods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pandi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    txt1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    txt2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    txt3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N1 = table.Column<int>(type: "int", nullable: false),
                    N2 = table.Column<int>(type: "int", nullable: false),
                    N3 = table.Column<int>(type: "int", nullable: false),
                    Packet = table.Column<float>(type: "real", nullable: false),
                    PKTQty = table.Column<float>(type: "real", nullable: false),
                    Post = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    BrachID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SaleSubs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SMID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Packet = table.Column<float>(type: "real", nullable: false),
                    PktQty = table.Column<float>(type: "real", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    DisRS = table.Column<float>(type: "real", nullable: false),
                    DisPer = table.Column<float>(type: "real", nullable: false),
                    NetRate = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    STRG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommisionRs = table.Column<float>(type: "real", nullable: false),
                    CommisionPer = table.Column<float>(type: "real", nullable: false),
                    Bardana = table.Column<float>(type: "real", nullable: false),
                    Tulai = table.Column<float>(type: "real", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    Sync = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SaleSubWarehouses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SMID = table.Column<int>(type: "int", nullable: false),
                    GodownID = table.Column<int>(type: "int", nullable: false),
                    Packet = table.Column<float>(type: "real", nullable: false),
                    PktQty = table.Column<float>(type: "real", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
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
                name: "SaleMains");

            migrationBuilder.DropTable(
                name: "SaleSubs");

            migrationBuilder.DropTable(
                name: "SaleSubWarehouses");
        }
    }
}
