using AutoMapper;
using BussinessModels.DBModels;
using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AppDbContext _context;
        DataTable dtSalesMain, dtSalesSub, dtSaleSubWarehouse;
        public SalesRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
            dtSalesMain = new DataTable();
            dtSalesMain.Columns.Add("BillNo", typeof(string));
            dtSalesMain.Columns.Add("SAccID", typeof(int));
            dtSalesMain.Columns.Add("GSale", typeof(Single));
            dtSalesMain.Columns.Add("SReturn", typeof(Single));
            dtSalesMain.Columns.Add("DiscountUser", typeof(Single));
            dtSalesMain.Columns.Add("CashRece", typeof(Single));
            dtSalesMain.Columns.Add("ChangeReturn", typeof(Single));
            dtSalesMain.Columns.Add("AgentID", typeof(int));
            dtSalesMain.Columns.Add("txt1", typeof(string));
            dtSalesMain.Columns.Add("N1", typeof(int));
            dtSalesMain.Columns.Add("N2", typeof(int));
            dtSalesMain.Columns.Add("Goods", typeof(string));
            dtSalesMain.Columns.Add("ContactNo", typeof(string));
            dtSalesMain.Columns.Add("CashAddress", typeof(string));
            dtSalesMain.Columns.Add("Pandi", typeof(string));
            dtSalesMain.Columns.Add("Remarks", typeof(string));
            dtSalesMain.Columns.Add("Packet", typeof(Single));
            dtSalesMain.Columns.Add("PKTQty", typeof(Single));
            dtSalesMain.Columns.Add("CompanyID", typeof(int));
            dtSalesMain.Columns.Add("OperatorID", typeof(int));
            dtSalesMain.Columns.Add("BranchID", typeof(int));
            dtSalesMain.Columns.Add("LocationID", typeof(int));

            dtSalesSub = new DataTable();
            dtSalesSub.Columns.Add("SSID", typeof(int));
            dtSalesSub.Columns.Add("ItemID", typeof(int));
            dtSalesSub.Columns.Add("ItemDescription", typeof(string));
            dtSalesSub.Columns.Add("Unit", typeof(string));
            dtSalesSub.Columns.Add("Packet", typeof(Single));
            dtSalesSub.Columns.Add("PktQty", typeof(Single));
            dtSalesSub.Columns.Add("Qty", typeof(Single));
            dtSalesSub.Columns.Add("Rate", typeof(Single));
            dtSalesSub.Columns.Add("DisRS", typeof(Single));
            dtSalesSub.Columns.Add("DisPer", typeof(Single));
            dtSalesSub.Columns.Add("NetRate", typeof(Single));
            dtSalesSub.Columns.Add("Amount", typeof(Single));
            dtSalesSub.Columns.Add("STRG", typeof(string));
            dtSalesSub.Columns.Add("CompanyID", typeof(int));
            dtSalesSub.Columns.Add("BranchID", typeof(int));

            
            dtSaleSubWarehouse = new DataTable();
            dtSaleSubWarehouse.Columns.Add("SSID", typeof(int));
            dtSaleSubWarehouse.Columns.Add("SWID", typeof(int));
            dtSaleSubWarehouse.Columns.Add("GodownID", typeof(int));
            dtSaleSubWarehouse.Columns.Add("ItemID", typeof(int));
            dtSaleSubWarehouse.Columns.Add("Qty", typeof(int));
            dtSaleSubWarehouse.Columns.Add("CompanyID", typeof(int));
            dtSaleSubWarehouse.Columns.Add("BranchID", typeof(int));



        }

        public async Task<string> SaveSales(SalesMainVM salesmain)
        {
            var maxSWID=new SaleSubWarehouse();
            var maxSSID = new SaleSub();
            initDT();
            if (dtSalesMain.Rows.Count > 0)
            {
                dtSalesMain.Rows.Clear();
            }
            if (salesmain.SMID == 0) 
            {
                maxSWID = this._context.SaleSubWarehouse.OrderByDescending(x => x.SWID).FirstOrDefault();
                if (maxSWID == null)
                {
                    maxSWID = new SaleSubWarehouse();
                    maxSWID.SWID = 0;
                }

                maxSSID = this._context.SaleSub.OrderByDescending(x => x.SSID).FirstOrDefault();
                if (maxSSID == null)
                {
                    maxSSID = new SaleSub();
                    maxSSID.SSID = 0;
                }
            }

            if (salesmain.SaleDetail.Count > 0)
            {
                try
                {
                    DataRow row = dtSalesMain.NewRow();

                    row["BillNo"] = salesmain.BillNo;
                    row["SAccID"] = salesmain.SAccID;
                    row["GSale"] = salesmain.GSale;
                    row["SReturn"] = salesmain.SReturn;
                    row["DiscountUser"] = salesmain.DiscountUser;
                    row["CashRece"] = salesmain.CashRece;
                    row["ChangeReturn"] = salesmain.ChangeReturn;
                    row["AgentID"] = salesmain.AgentID;
                    row["txt1"] = salesmain.txt1;
                    row["N1"] = salesmain.N1;
                    row["N2"] = salesmain.N2;
                    row["Goods"] = salesmain.Goods;
                    row["ContactNo"] = salesmain.ContactNo;
                    row["CashAddress"] = salesmain.CashAddress;
                    row["Pandi"] = salesmain.Pandi;
                    row["Remarks"] = salesmain.Remarks;
                    row["Packet"] = salesmain.Packet;
                    row["PKTQty"] = salesmain.PKTQty;
                    row["CompanyID"] = salesmain.CompanyID;
                    row["OperatorID"] = salesmain.OperatorID;
                    row["BranchID"] = salesmain.BranchID;
                    row["LocationID"] = salesmain.LocationID;

                    dtSalesMain.Rows.InsertAt(row, 0);

                    int swid = 0;
                    int ssid = 0;
                    swid = maxSWID.SWID;
                    ssid = maxSSID.SSID;

                    int i = 0;
                    foreach (var detail in salesmain.SaleDetail)
                    {

                        DataRow srow = dtSalesSub.NewRow();
                        if (salesmain.SMID == 0)
                        {
                            ssid = ssid + 1;
                            srow["SSID"] = ssid;
                        }
                        else
                        {
                            srow["SSID"] = detail.SSID;
                        }

                        srow["ItemID"] = detail.ItemID;
                        srow["ItemDescription"] = detail.ItemDescription;
                        srow["Unit"] = detail.Unit;
                        srow["Packet"] = detail.Packet;
                        srow["PktQty"] = detail.PktQty;
                        srow["Qty"] = detail.Qty;
                        srow["Rate"] = detail.Rate;
                        srow["DisRS"] = detail.DisRS;
                        srow["DisPer"] = detail.DisPer;
                        srow["NetRate"] = detail.NetRate;
                        srow["Amount"] = detail.Amount;
                        srow["STRG"] = detail.STRG;
                        srow["CompanyID"] = detail.CompanyID;
                        srow["BranchID"] = detail.BranchID;

                        dtSalesSub.Rows.InsertAt(srow, i);

                        for (int index = 0; index < detail.SaleDetailWarehouse.Count; index++)
                        {

                            DataRow rr = dtSaleSubWarehouse.NewRow();
                            if (salesmain.SMID == 0)
                            {
                                
                                
                                swid = swid + 1;
                                rr["SWID"] =swid;
                                rr["SSID"] = ssid;
                            }
                            else 
                            {
                                rr["SWID"] = detail.SaleDetailWarehouse[index].SWID;
                                rr["SSID"] = detail.SaleDetailWarehouse[index].SSID;

                            }

                            
                            rr["GodownID"] = detail.SaleDetailWarehouse[index].GodownID;
                            rr["ItemID"] = detail.ItemID;
                            rr["Qty"] = detail.SaleDetailWarehouse[index].Qty;
                            rr["CompanyID"] = detail.SaleDetailWarehouse[index].CompanyID;
                            rr["BranchID"] = detail.SaleDetailWarehouse[index].BranchID;


                            dtSaleSubWarehouse.Rows.InsertAt(rr, index);
                        }
                     
                        i++;
                    }


                    



                    using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                    {
                        //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
                        //SqlConnection cn = null;
                        SqlCommand cmd = null;

                        //cn = new SqlConnection(CS);


                        cmd = new SqlCommand("dbo.Insert_Sales", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SMain", SqlDbType.Structured).Value = dtSalesMain;
                        cmd.Parameters.Add("@SSub", SqlDbType.Structured).Value = dtSalesSub;
                        cmd.Parameters.Add("@SSubWarehouse", SqlDbType.Structured).Value = dtSaleSubWarehouse;
                        cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@SmId", SqlDbType.BigInt).Value = salesmain.SMID;



                        var returnParameter = cmd.Parameters.Add("@SmId", SqlDbType.BigInt);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        con.Open();
                        await cmd.ExecuteNonQueryAsync();
                        var result = returnParameter.Value;
                        con.Close();


                        return "Record Saved Successfully for ID:" + result;



                    }


                }
                catch (Exception ex)
                {

                    throw new Exception("Insert Failed");
                }




            }

            return "Enter Valid Data First";

        }

        public async Task<IList<SalesMainVM>> GetAllSales()
        {
            var list=  await this._context.SaleMain.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<SalesMainVM> salesList = JsonConvert.DeserializeObject<IList<SalesMainVM>>(json);

            return salesList;
        }

        public async Task<SalesMainVM> GetSaleByID(int Id) 
        {
            SalesMainVM salemainobj = new SalesMainVM();

           
            var mainsale  = this._context.SaleMain.Where(x => x.SMID == Id).FirstOrDefault();

            var mainjson = JsonConvert.SerializeObject(mainsale);

            salemainobj = JsonConvert.DeserializeObject<SalesMainVM>(mainjson);

            if (salemainobj != null)
            {
                var subsale = await  this._context.SaleSub.Where(x => x.SMID == salemainobj.SMID).ToListAsync();
                var subjson = JsonConvert.SerializeObject(subsale);
                salemainobj.SaleDetail = JsonConvert.DeserializeObject<List<SaleSubVm>>(subjson);

                foreach (var subsaleitem in salemainobj.SaleDetail)
                {
                    var house = await this._context.SaleSubWarehouse.Where(x => x.SSID == subsaleitem.SSID).ToListAsync();

                    var housejson = JsonConvert.SerializeObject(house);
                    subsaleitem.SaleDetailWarehouse = JsonConvert.DeserializeObject<IList<SaleSubWarehouseVM>>(housejson);

                }

            }

            return salemainobj;
        }

        public async Task<string> DeleteSale(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
              
                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.Add("@SmId", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                
                con.Close();


                return "Record Deleted Successfully";



            }
        
        }

        public async  Task<SalesLookUpsVM> GetLookUpsforSale()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@SubAccountLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@ItemLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@PandiLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@AddaLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };

                
                var sql = "EXEC[SalesGetSearchLookUps] @SubAccountLookUp OUTPUT, @ItemLookUp OUTPUT, @PandiLookUp OUTPUT, @AddaLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql,@params[0],@params[1], @params[2], @params[3]);


                
                SalesLookUpsVM lookups = new SalesLookUpsVM();




                lookups.salepartylookup = JsonConvert.DeserializeObject<IList<SalePartyLookUp>>(@params[0].Value.ToString());
                lookups.saleitemlookup = JsonConvert.DeserializeObject<IList<SaleItemLookupVM>>(@params[1].Value.ToString());
                lookups.salepandilookup = JsonConvert.DeserializeObject<IList<SalePandiLookUpVM>>(@params[2].Value.ToString());
                lookups.saleaddalookup = JsonConvert.DeserializeObject<IList<SaleAddaLookUpVM>>(@params[3].Value.ToString());
                


                con.Close();


                return lookups;



            }
        }

    }
}
