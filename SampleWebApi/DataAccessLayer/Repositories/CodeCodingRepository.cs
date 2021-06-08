using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CodeCodingRepository : ICodeCodingRepository
    {
        private readonly AppDbContext _context;
        DataTable dtCodeMain, dtCodeProduction, dtCodeWareHouse;
        public CodeCodingRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT() 
        {

            dtCodeMain = new DataTable();

            dtCodeMain.Columns.Add("CodeName", typeof(string));
            dtCodeMain.Columns.Add("ClassID", typeof(int));
            dtCodeMain.Columns.Add("PCateID", typeof(int));
            dtCodeMain.Columns.Add("PTypeID", typeof(int));
            dtCodeMain.Columns.Add("Barcode", typeof(string));
            dtCodeMain.Columns.Add("Code", typeof(string));
            dtCodeMain.Columns.Add("SaleRate", typeof(Single));
            dtCodeMain.Columns.Add("OptionsID", typeof(int));
            dtCodeMain.Columns.Add("CommRate", typeof(Single));
            dtCodeMain.Columns.Add("CostRate", typeof(Single));
            dtCodeMain.Columns.Add("BoxQty", typeof(Single));
            dtCodeMain.Columns.Add("MinRate", typeof(Single));
            dtCodeMain.Columns.Add("BoraQty", typeof(Single));
            dtCodeMain.Columns.Add("AdminMinRate", typeof(Single));
            dtCodeMain.Columns.Add("BundleQty", typeof(Single));
            dtCodeMain.Columns.Add("ItemDescription", typeof(string));
            dtCodeMain.Columns.Add("CompanyID", typeof(int));
            dtCodeMain.Columns.Add("BranchID", typeof(int));
            dtCodeMain.Columns.Add("OperatorID", typeof(int));


            dtCodeProduction = new DataTable();

            dtCodeProduction.Columns.Add("Gatta", typeof(Single));
            dtCodeProduction.Columns.Add("TitleMaterial", typeof(Single));
            dtCodeProduction.Columns.Add("Astar", typeof(Single));
            dtCodeProduction.Columns.Add("InnerMaterial", typeof(Single));
            dtCodeProduction.Columns.Add("Pages", typeof(Single));
            dtCodeProduction.Columns.Add("Printing", typeof(Single));
            dtCodeProduction.Columns.Add("CompanyID", typeof(int));
            dtCodeProduction.Columns.Add("BranchID", typeof(int));

            dtCodeWareHouse = new DataTable();


            dtCodeWareHouse.Columns.Add("GodownID", typeof(int));
            dtCodeWareHouse.Columns.Add("Qty", typeof(Single));
            dtCodeWareHouse.Columns.Add("CompanyID", typeof(int));
            dtCodeWareHouse.Columns.Add("BranchID", typeof(int));
        

        }

        public async Task<string> SaveProduct(CodeCodingMainVM codemain)
        {
            if(dtCodeMain.Rows.Count > 0) 
            {
                dtCodeMain.Rows.Clear();
            }
            if(dtCodeProduction.Rows.Count > 0) 
            {
                dtCodeProduction.Rows.Clear();
            }
            if(dtCodeWareHouse.Rows.Count > 0) 
            {
                dtCodeWareHouse.Rows.Clear();
            }

            try 
            {
                DataRow row = dtCodeMain.NewRow();

                row["CodeName"] = codemain.CodeName;
                row["ClassID"] = codemain.ClassID;
                row["PCateID"] = codemain.PCateID;
                row["PTypeID"] = codemain.PTypeID;
                row["Barcode"] = codemain.Barcode;
                row["Code"] = codemain.Code;
                row["SaleRate"] = codemain.SaleRate;
                row["OptionsID"] = codemain.OptionsID;
                row["CommRate"] = codemain.CommRate;
                row["CostRate"] = codemain.CostRate;
                row["BoxQty"] = codemain.BoxQty;
                row["MinRate"] = codemain.MinRate;
                row["BoraQty"] = codemain.BoraQty;
                row["AdminMinRate"] = codemain.AdminMinRate;
                row["BundleQty"] = codemain.BundleQty;
                row["ItemDescription"] = codemain.ItemDescription;
                row["CompanyID"] = codemain.CompanyID;
                row["BranchID"] = codemain.BranchID;
                row["OperatorID"] = codemain.OperatorID;

                dtCodeMain.Rows.InsertAt(row, 0);


                int i = 0;
                foreach (var warehouse in codemain.CodeWarehouse)
                {
                    DataRow wrow = dtCodeWareHouse.NewRow();
                    wrow["GodownID"] = warehouse.GodownID;
                    wrow["Qty"] = warehouse.Qty;
                    wrow["CompanyID"] = warehouse.CompanyID;
                    wrow["BranchID"] = warehouse.BranchID;

                    dtCodeWareHouse.Rows.InsertAt(wrow, i);

                }


                int ii = 0;
                foreach (var production in codemain.CodeProduction)
                {
                    DataRow prow = dtCodeProduction.NewRow();

                    prow["Gatta"] = production.Gatta;
                    prow["TitleMaterial"] = production.TitleMaterial;
                    prow["Astar"] = production.Astar;
                    prow["InnerMaterial"] = production.InnerMaterial;
                    prow["Pages"] = production.Pages;
                    prow["Printing"] = production.Printing;
                    prow["CompanyID"] = production.CompanyID;
                    prow["BranchID"] = production.BranchID;

                    dtCodeProduction.Rows.InsertAt(prow, ii);

                }


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                  
                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Insert_SaleReturn", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CMain", SqlDbType.Structured).Value = dtCodeMain;
                    cmd.Parameters.Add("@CWarehouse", SqlDbType.Structured).Value = dtCodeWareHouse;
                    cmd.Parameters.Add("@CProduction", SqlDbType.Structured).Value = dtCodeProduction;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = codemain.EDate;
                    cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = codemain.CID;



                    var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return result.ToString();



                }


            }
            catch(Exception ex) 
            {
                throw ex;
            }



           
        }





        public Task<string> DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CodeCodingMainVM>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<CodeCodingLookUpsVM> GetLookUpsforProduct()
        {
            throw new NotImplementedException();
        }

        public Task<CodeCodingMainVM> GetProductByID(int Id)
        {
            throw new NotImplementedException();
        }

       
    }
}
