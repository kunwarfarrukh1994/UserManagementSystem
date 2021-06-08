using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CodeCodingMainChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BCID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "BatchFile",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "Block",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "CommPer",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "CommRS",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "DesignNo",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "DiscountPer",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "DiscountRs",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "DpttCID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "GRNCID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "GRNDate",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "IRange",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "ItemCID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "MadeIn",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "OpenQty",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "OpeningBit",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "PCostRate",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "PSaleRate",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "PacketQty",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "PartyID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "PurchaseType",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "Qty",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "ReOrderLevel",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "Remarks",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "Season",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "SizeRange",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "SubCategoryCID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "SuitLength",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "T1",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "T2",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "VendorCode",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "VolumeCID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.RenameColumn(
                name: "Packet",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "PTypeID");

            migrationBuilder.RenameColumn(
                name: "Ignore",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "PCateID");

            migrationBuilder.RenameColumn(
                name: "FinID",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "CompanyID");

            migrationBuilder.RenameColumn(
                name: "Colours",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "ClassID");

            migrationBuilder.AlterColumn<float>(
                name: "Qty",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "GodownID",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "TitleMaterial",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Printing",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Pages",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "InnerMaterial",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Gatta",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Astar",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "SaleRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "CostRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "AdminMinRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BoraQty",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BoxQty",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BundleQty",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CommRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MinRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionsID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminMinRate",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "BoraQty",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "BoxQty",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "BundleQty",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "CommRate",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "ItemDescription",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "MinRate",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.DropColumn(
                name: "OptionsID",
                schema: "dbo",
                table: "CodeCodingMain");

            migrationBuilder.RenameColumn(
                name: "PTypeID",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "Packet");

            migrationBuilder.RenameColumn(
                name: "PCateID",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "Ignore");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "FinID");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                schema: "dbo",
                table: "CodeCodingMain",
                newName: "Colours");

            migrationBuilder.AlterColumn<float>(
                name: "Qty",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GodownID",
                schema: "dbo",
                table: "CodeCodingWarehouse",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TitleMaterial",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Printing",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Pages",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "InnerMaterial",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Gatta",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Astar",
                schema: "dbo",
                table: "CodeCodingProduction",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "SaleRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CostRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BCID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "BatchFile",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Block",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "CommPer",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CommRS",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DesignNo",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "DiscountPer",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DiscountRs",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "DpttCID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "GRNCID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "GRNDate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IRange",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "ItemCID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "MadeIn",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "OpenQty",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<short>(
                name: "OpeningBit",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<float>(
                name: "PCostRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PSaleRate",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PacketQty",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PartyID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseType",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Qty",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ReOrderLevel",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Season",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SizeRange",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "SubCategoryCID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SuitLength",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "T1",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "T2",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VendorCode",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "VolumeCID",
                schema: "dbo",
                table: "CodeCodingMain",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
