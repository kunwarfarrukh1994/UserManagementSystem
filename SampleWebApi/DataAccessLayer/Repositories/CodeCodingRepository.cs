using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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


                DataRow prow = dtCodeProduction.NewRow();

                prow["Gatta"] = codemain.CodeProduction.Gatta;
                prow["TitleMaterial"] = codemain.CodeProduction.TitleMaterial;
                prow["Astar"] = codemain.CodeProduction.Astar;
                prow["InnerMaterial"] = codemain.CodeProduction.InnerMaterial;
                prow["Pages"] = codemain.CodeProduction.Pages;
                prow["Printing"] = codemain.CodeProduction.Printing;
                prow["CompanyID"] = codemain.CodeProduction.CompanyID;
                prow["BranchID"] = codemain.CodeProduction.BranchID;

                dtCodeProduction.Rows.InsertAt(prow, 0);








                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                  
                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Insert_CodeCoding", con);
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




        public async Task<string> DeleteProduct(int Id, int CompanyId)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_CodeCoding", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = Id;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyId;

                var returnParameter = cmd.Parameters.Add("@CID", SqlDbType.BigInt);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                var result = returnParameter.Value;
                con.Close();

                return result.ToString();


            }
        }




        public async Task<IList<CodeCodingMainVM>> GetAllProducts(int CompanyID)
        {
            SqlParameter[] @outparams =
                {
                       new SqlParameter("@CodeCodingMain", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };
            SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyID", CompanyID)


                };
            await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllCodeCodings", this._context);

            IList<CodeCodingMainVM> codeList = JsonConvert.DeserializeObject<IList<CodeCodingMainVM>>(@outparams[0].Value.ToString());


            return codeList;

            //using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            //{
            //    SqlParameter[] @params =
            //        {
            //           new SqlParameter("@CodeCodingMain", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

            //    };


            //    var sql = "EXEC[Get_AllCodeCodings] @CodeCodingMain OUTPUT; ";
            //    await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);


            //    IList<CodeCodingMainVM> codeList = JsonConvert.DeserializeObject<IList<CodeCodingMainVM>>(@params[0].Value.ToString());

                
               

            //    con.Close();


            //    return codeList;



            //}
        }

        public async Task<CodeCodingLookUpsVM> GetLookUpsforProduct(int CompanyID)
        {
            SqlParameter[] @outparams =
                 {
                        new SqlParameter("@CategoryLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@TypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@OptionsLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@ClassLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@GodownLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };
            SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyID", CompanyID)
                };
            await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_SearchLookUpsCodeCoding", this._context);

            CodeCodingLookUpsVM lookups = new CodeCodingLookUpsVM();

            lookups.categorylookup = JsonConvert.DeserializeObject<IList<CodeCodingCategoryLookUpVM>>(@outparams[0].Value.ToString());
            lookups.typelookup = JsonConvert.DeserializeObject<IList<CodeCodingTypeLookUpVM>>(@outparams[1].Value.ToString());
            lookups.optionslookup = JsonConvert.DeserializeObject<IList<CodeCodingOptionsLookUpVM>>(@outparams[2].Value.ToString());
            lookups.classlookup = JsonConvert.DeserializeObject<IList<CodeCodingClassLookUpVM>>(@outparams[3].Value.ToString());
            lookups.godownlookup = JsonConvert.DeserializeObject<IList<CodeCodingGodownLookUpVM>>(@outparams[4].Value.ToString());

            return lookups;


            //SqlParameter[] @params =
            //      {
            //           new SqlParameter("@CategoryLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
            //           new SqlParameter("@TypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
            //           new SqlParameter("@OptionsLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
            //           new SqlParameter("@ClassLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
            //           new SqlParameter("@GodownLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

            //    };

            //await DBMethods.EXECUTE_SP(new SqlParameter[0], @params, "Get_SearchLookUpsCodeCoding", this._context);

            //CodeCodingLookUpsVM lookups = new CodeCodingLookUpsVM();

            //lookups.categorylookup = JsonConvert.DeserializeObject<IList<CodeCodingCategoryLookUpVM>>(@params[0].Value.ToString());
            //lookups.typelookup = JsonConvert.DeserializeObject<IList<CodeCodingTypeLookUpVM>>(@params[1].Value.ToString());
            //lookups.optionslookup = JsonConvert.DeserializeObject<IList<CodeCodingOptionsLookUpVM>>(@params[2].Value.ToString());
            //lookups.classlookup = JsonConvert.DeserializeObject<IList<CodeCodingClassLookUpVM>>(@params[3].Value.ToString());
            //lookups.godownlookup = JsonConvert.DeserializeObject<IList<CodeCodingGodownLookUpVM>>(@params[4].Value.ToString());

            //return lookups;
        }

        public async Task<CodeCodingMainVM> GetProductByID(int Id, int CompanyID)
        {
            CodeCodingMainVM codemainobj = new CodeCodingMainVM();


            var maincode = this._context.CodeCodingMain.Where(x => x.CID == Id && x.CompanyID == CompanyID).FirstOrDefault();

            var mainjson = JsonConvert.SerializeObject(maincode);

            codemainobj = JsonConvert.DeserializeObject<CodeCodingMainVM>(mainjson);

            if (codemainobj != null)
            {
                var codewarehouse = await this._context.CodeCodingWarehouse.Where(x => x.CID == codemainobj.CID && x.CompanyID == CompanyID).ToListAsync();
                var subjson = JsonConvert.SerializeObject(codewarehouse);
                codemainobj.CodeWarehouse = JsonConvert.DeserializeObject<List<CodeCodingWarehouseVM>>(subjson);


                var codeproduction = await this._context.CodeCodingProduction.Where(x => x.CID == codemainobj.CID && x.CompanyID == CompanyID).FirstOrDefaultAsync();
                var prodjson = JsonConvert.SerializeObject(codeproduction);
                codemainobj.CodeProduction = JsonConvert.DeserializeObject<CodeCodingProductionVM>(prodjson);



            }

            return codemainobj;
        }
    }
}











//public async Task<CodeCodingMainVM> GetProductByID(int Id)
//{
//    //CodeCodingMainVM codeMain = new CodeCodingMainVM();

//    //var maincode = this._context.CodeCodingMain.Where(x => x.CID == Id).FirstOrDefault();

//    //var mainjson = JsonConvert.SerializeObject(maincode);

//    //codeMain = JsonConvert.DeserializeObject<CodeCodingMainVM>(mainjson);

//    SqlParameter[] @outparams =
//           {
//               new SqlParameter("@CodeCodingMain", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
//               new SqlParameter("@CodeCodingWarehouse", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
//               new SqlParameter("@CodeCodingProduction", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},

//        };
//    SqlParameter[] @inparams =
//        {
//            new SqlParameter("@CID", Id)
//        };
//    await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_CodeCodingByID", this._context);


//    CodeCodingMainVM codeMain = new CodeCodingMainVM();
//    var mainjson = @outparams[0].Value.ToString();


//    codeMain = JsonConvert.DeserializeObject<CodeCodingMainVM>(mainjson);
//    if (codeMain != null) 
//    {
//        //List<CodeCodingWarehouseVM> codewarehouse = JsonConvert.DeserializeObject<List<CodeCodingWarehouseVM>>(@outparams[1].Value.ToString());
//        //List<CodeCodingProductionVM> codeproduction = JsonConvert.DeserializeObject<List<CodeCodingProductionVM>>(@outparams[2].Value.ToString());


//        codeMain.CodeWarehouse = JsonConvert.DeserializeObject<List<CodeCodingWarehouseVM>>(@outparams[0].Value.ToString());
//        codeMain.CodeProduction = JsonConvert.DeserializeObject<CodeCodingProductionVM>(@outparams[1].Value.ToString());

//    }







//    return codeMain;
//}