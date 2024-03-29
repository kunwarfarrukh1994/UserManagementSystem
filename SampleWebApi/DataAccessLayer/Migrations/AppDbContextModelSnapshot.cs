﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("BussinessModels.DBModels.CodeCodingMain", b =>
                {
                    b.Property<float>("BCID")
                        .HasColumnType("real");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BatchFile")
                        .HasColumnType("int");

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<float>("CID")
                        .HasColumnType("real");

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Colours")
                        .HasColumnType("int");

                    b.Property<float>("CommPer")
                        .HasColumnType("real");

                    b.Property<float>("CommRS")
                        .HasColumnType("real");

                    b.Property<float>("CostRate")
                        .HasColumnType("real");

                    b.Property<int>("Del")
                        .HasColumnType("int");

                    b.Property<string>("DesignNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DiscountPer")
                        .HasColumnType("real");

                    b.Property<float>("DiscountRs")
                        .HasColumnType("real");

                    b.Property<float>("DpttCID")
                        .HasColumnType("real");

                    b.Property<DateTime>("EDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinID")
                        .HasColumnType("int");

                    b.Property<float>("GRNCID")
                        .HasColumnType("real");

                    b.Property<DateTime>("GRNDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("IRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ignore")
                        .HasColumnType("int");

                    b.Property<float>("ItemCID")
                        .HasColumnType("real");

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("OpenQty")
                        .HasColumnType("real");

                    b.Property<short>("OpeningBit")
                        .HasColumnType("smallint");

                    b.Property<float>("PCostRate")
                        .HasColumnType("real");

                    b.Property<float>("PSaleRate")
                        .HasColumnType("real");

                    b.Property<int>("Packet")
                        .HasColumnType("int");

                    b.Property<float>("PacketQty")
                        .HasColumnType("real");

                    b.Property<float>("PartyID")
                        .HasColumnType("real");

                    b.Property<string>("PurchaseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Qty")
                        .HasColumnType("real");

                    b.Property<float>("ReOrderLevel")
                        .HasColumnType("real");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SaleRate")
                        .HasColumnType("real");

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SizeRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SubCategoryCID")
                        .HasColumnType("real");

                    b.Property<float>("SuitLength")
                        .HasColumnType("real");

                    b.Property<int>("Sync")
                        .HasColumnType("int");

                    b.Property<string>("T1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("T2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("VolumeCID")
                        .HasColumnType("real");

                    b.ToTable("CodeCodingMain");
                });

            modelBuilder.Entity("BussinessModels.DBModels.GoDown", b =>
                {
                    b.Property<int>("FinId")
                        .HasColumnType("int");

                    b.Property<int>("GoCid")
                        .HasColumnType("int");

                    b.Property<string>("GoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.ToTable("GoDown");
                });

            modelBuilder.Entity("BussinessModels.DBModels.SaleMain", b =>
                {
                    b.Property<int?>("AgentID")
                        .HasColumnType("int");

                    b.Property<int?>("AgentID2")
                        .HasColumnType("int");

                    b.Property<string>("BillNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("BiltyExp")
                        .HasColumnType("real");

                    b.Property<int?>("BiltyNo")
                        .HasColumnType("int");

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("CashAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("CashRece")
                        .HasColumnType("real");

                    b.Property<float?>("ChangeReturn")
                        .HasColumnType("real");

                    b.Property<string>("ChqRece")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("CommissionExp")
                        .HasColumnType("real");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreditDays")
                        .HasColumnType("int");

                    b.Property<int?>("Del")
                        .HasColumnType("int");

                    b.Property<float?>("DiscountUser")
                        .HasColumnType("real");

                    b.Property<DateTime>("EDate")
                        .HasColumnType("datetime2");

                    b.Property<float?>("FreightExp")
                        .HasColumnType("real");

                    b.Property<float?>("GSale")
                        .HasColumnType("real");

                    b.Property<string>("Goods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ID")
                        .HasColumnType("int");

                    b.Property<int?>("LocationID")
                        .HasColumnType("int");

                    b.Property<int?>("N1")
                        .HasColumnType("int");

                    b.Property<int?>("N2")
                        .HasColumnType("int");

                    b.Property<int?>("N3")
                        .HasColumnType("int");

                    b.Property<int?>("OperatorID")
                        .HasColumnType("int");

                    b.Property<float?>("OtherExp")
                        .HasColumnType("real");

                    b.Property<float?>("PKTQty")
                        .HasColumnType("real");

                    b.Property<float?>("Packet")
                        .HasColumnType("real");

                    b.Property<string>("Pandi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Post")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SAccID")
                        .HasColumnType("int");

                    b.Property<int?>("SMID")
                        .HasColumnType("int");

                    b.Property<float?>("SReturn")
                        .HasColumnType("real");

                    b.Property<int?>("Sync")
                        .HasColumnType("int");

                    b.Property<string>("txt1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("txt3")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ID")
                        .IsUnique()
                        .HasFilter("[ID] IS NOT NULL");

                    b.ToTable("SaleMain");
                });

            modelBuilder.Entity("BussinessModels.DBModels.SaleParty", b =>
                {
                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BCID")
                        .HasColumnType("int");

                    b.Property<string>("BalType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<float>("CID")
                        .HasColumnType("real");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ControlACCID")
                        .HasColumnType("real");

                    b.Property<float>("CreditLimit")
                        .HasColumnType("real");

                    b.Property<int>("Del")
                        .HasColumnType("int");

                    b.Property<DateTime>("EDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ID")
                        .HasColumnType("real");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("N1")
                        .HasColumnType("smallint");

                    b.Property<short>("N2")
                        .HasColumnType("smallint");

                    b.Property<short>("N3")
                        .HasColumnType("smallint");

                    b.Property<short>("N4")
                        .HasColumnType("smallint");

                    b.Property<string>("NTN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("OPBal")
                        .HasColumnType("real");

                    b.Property<int>("OperatorID")
                        .HasColumnType("int");

                    b.Property<string>("PartyConcate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartyType")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleMan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sync")
                        .HasColumnType("int");

                    b.ToTable("SaleParty");
                });

            modelBuilder.Entity("BussinessModels.DBModels.SaleSub", b =>
                {
                    b.Property<float?>("Amount")
                        .HasColumnType("real");

                    b.Property<float?>("Bardana")
                        .HasColumnType("real");

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<float?>("CommisionPer")
                        .HasColumnType("real");

                    b.Property<float?>("CommisionRs")
                        .HasColumnType("real");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<int?>("Del")
                        .HasColumnType("int");

                    b.Property<float?>("DisPer")
                        .HasColumnType("real");

                    b.Property<float?>("DisRS")
                        .HasColumnType("real");

                    b.Property<int?>("ID")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemID")
                        .HasColumnType("int");

                    b.Property<float?>("NetRate")
                        .HasColumnType("real");

                    b.Property<float?>("Packet")
                        .HasColumnType("real");

                    b.Property<float?>("PktQty")
                        .HasColumnType("real");

                    b.Property<float?>("Qty")
                        .HasColumnType("real");

                    b.Property<float?>("Rate")
                        .HasColumnType("real");

                    b.Property<int?>("SMID")
                        .HasColumnType("int");

                    b.Property<int>("SSID")
                        .HasColumnType("int");

                    b.Property<string>("STRG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sync")
                        .HasColumnType("int");

                    b.Property<float?>("Tulai")
                        .HasColumnType("real");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ID")
                        .IsUnique()
                        .HasFilter("[ID] IS NOT NULL");

                    b.ToTable("SaleSub");
                });

            modelBuilder.Entity("BussinessModels.DBModels.SaleSubWarehouse", b =>
                {
                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<int?>("Del")
                        .HasColumnType("int");

                    b.Property<int?>("GodownID")
                        .HasColumnType("int");

                    b.Property<int?>("ID")
                        .HasColumnType("int");

                    b.Property<int?>("ItemID")
                        .HasColumnType("int");

                    b.Property<float?>("Packet")
                        .HasColumnType("real");

                    b.Property<float?>("PktQty")
                        .HasColumnType("real");

                    b.Property<float?>("Qty")
                        .HasColumnType("real");

                    b.Property<int>("SMID")
                        .HasColumnType("int");

                    b.Property<int>("SSID")
                        .HasColumnType("int");

                    b.Property<int>("SWID")
                        .HasColumnType("int");

                    b.Property<int?>("Sync")
                        .HasColumnType("int");

                    b.ToTable("SaleSubWarehouse");
                });

            modelBuilder.Entity("BussinessModels.DBModels.SubAccount", b =>
                {
                    b.Property<int>("AccCodeCr")
                        .HasColumnType("int");

                    b.Property<int>("AccCodeDr")
                        .HasColumnType("int");

                    b.Property<int>("AccCodeID")
                        .HasColumnType("int");

                    b.Property<short>("Active")
                        .HasColumnType("smallint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baltype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinID")
                        .HasColumnType("int");

                    b.Property<long>("ID")
                        .HasColumnType("bigint");

                    b.Property<float>("OpBal")
                        .HasColumnType("real");

                    b.Property<string>("RegID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SAccDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("SAccID")
                        .HasColumnType("bigint");

                    b.Property<string>("SAccName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SAccNameU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("subAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
