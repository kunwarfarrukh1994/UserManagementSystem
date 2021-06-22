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
    public class CodeCodingCategoryRepository : ICodeCodingCategoryRepository
    {
        private readonly AppDbContext _context;
        DataTable dtPCate;
        public CodeCodingCategoryRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }
        public void initDT() 
        {

            dtPCate = new DataTable();
            dtPCate.Columns.Add("Title", typeof(string));
            dtPCate.Columns.Add("TitleU", typeof(string));
            dtPCate.Columns.Add("CompanyID", typeof(int));
            dtPCate.Columns.Add("BranchID", typeof(int));
            dtPCate.Columns.Add("OperatorID", typeof(int));
            

        }
        public async Task<string> SaveCategory(CodeCodingCategoryVM pCate)
        {
            if (dtPCate.Rows.Count > 0)
            {
                dtPCate.Rows.Clear();
            }
            try
            {
                DataRow row = dtPCate.NewRow();


                row["Title"] = pCate.Title;
                row["TitleU"] = pCate.TitleU;
                row["CompanyID"] = pCate.CompanyID;
                row["BranchID"] = pCate.BranchID;
                row["OperatorID"] = pCate.OperatorID;

                dtPCate.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_CodeCodingCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PCate", SqlDbType.Structured).Value = dtPCate;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = pCate.EDate;
                    cmd.Parameters.Add("@CateID", SqlDbType.BigInt).Value = pCate.CateID;



                    var returnParameter = cmd.Parameters.Add("@CateID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return result.ToString();



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }
        }


        public async Task<string> DeleteCategory(int Id, int CompanyId)
        {
            try
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_CodeCodingCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CateID", SqlDbType.BigInt).Value = Id;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyId;

                    var returnParameter = cmd.Parameters.Add("@CateID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();

                    return result.ToString();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed");
            }
        }

        public async Task<IList<CodeCodingCategoryVM>> GetAllCategories(int CompanyID)
        {
            try
            {
                SqlParameter[] @outparams =
               {
                       new SqlParameter("@PCateLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


                };
                SqlParameter[] @inparams =
                {
                     new SqlParameter("@CompanyID", CompanyID)
                };
                await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllCodeCodingCategories", this._context);

                IList<CodeCodingCategoryVM> pCates = JsonConvert.DeserializeObject<IList<CodeCodingCategoryVM>>(@outparams[0].Value.ToString());

                return pCates;
            }
            catch (Exception ex)
            {

                throw new Exception("Get All Categories Failed");
            }
        }

        public async Task<CodeCodingCategoryVM> GetCategoryByID(int Id, int CompanyID)
        {
            try
            {
                CodeCodingCategoryVM pCateObj = new CodeCodingCategoryVM();


                var mainCate = await this._context.CodeCodingCategory.Where(x => x.CateID == Id && x.CompanyID == CompanyID).FirstOrDefaultAsync();

                var mainjson = JsonConvert.SerializeObject(mainCate);

                pCateObj = JsonConvert.DeserializeObject<CodeCodingCategoryVM>(mainjson);



                return pCateObj;
            }

            catch (Exception ex)
            {

                throw new Exception("Get Product Category By ID Failed");
            }


            //SqlParameter[] @outparams = 
            //     {
            //           new SqlParameter("@PTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


            //    };
            //SqlParameter[] @inparams =
            //    {
            //        new SqlParameter("@TypeID", Id)
            //    };
            //await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_CodeCodingProductTypeByID", this._context);

            //CodeCodingProductTypeVM pType = JsonConvert.DeserializeObject<CodeCodingProductTypeVM>(@outparams[0].Value.ToString());

            //return pType;
        }


    }
}
