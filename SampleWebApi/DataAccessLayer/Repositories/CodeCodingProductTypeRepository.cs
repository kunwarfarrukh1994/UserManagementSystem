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
    public class CodeCodingProductTypeRepository : ICodeCodingProductTypeRepository
    {
        private readonly AppDbContext _context;
        DataTable dtPType;
        public CodeCodingProductTypeRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        { 
            dtPType = new DataTable();
            dtPType.Columns.Add("Title", typeof(string));
            dtPType.Columns.Add("TitleU", typeof(string));
            dtPType.Columns.Add("CompanyID", typeof(int));
            dtPType.Columns.Add("BranchID", typeof(int));
            dtPType.Columns.Add("OperatorID", typeof(int));
        }

        public async Task<string> SaveProductType(CodeCodingProductTypeVM pType)
        {
            if (dtPType.Rows.Count > 0)
            {
                dtPType.Rows.Clear();
            }
            try
            {
                DataRow row = dtPType.NewRow();


                row["Title"] = pType.Title;
                row["TitleU"] = pType.TitleU;
                row["CompanyID"] = pType.CompanyID;
                row["BranchID"] = pType.BranchID;
                row["OperatorID"] = pType.OperatorID;

                dtPType.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_CodeCodingProductType", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PType", SqlDbType.Structured).Value = dtPType;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = pType.EDate;
                    cmd.Parameters.Add("@TypeID", SqlDbType.BigInt).Value = pType.TypeID;



                    var returnParameter = cmd.Parameters.Add("@TypeID", SqlDbType.BigInt);
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




        public async Task<string> DeleteProductType(int Id, int CompanyId)
        {
            try 
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_CodeCodingProductType", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TypeID", SqlDbType.BigInt).Value = Id;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyId;

                    var returnParameter = cmd.Parameters.Add("@TypeID", SqlDbType.BigInt);
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

        public async Task<IList<CodeCodingProductTypeVM>> GetAllProductTypes(int CompanyId)
        {
            try 
            {
                SqlParameter[] @outparams =
               {
                       new SqlParameter("@PTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


                };
                SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyID", CompanyId)
                };
                await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllCodeCodingProductType", this._context);

                IList<CodeCodingProductTypeVM> pTypes = JsonConvert.DeserializeObject<IList<CodeCodingProductTypeVM>>(@outparams[0].Value.ToString());

                return pTypes;
            }
            catch (Exception ex)
            {

                throw new Exception("Get All Failed");
            }





            //var list = await this._context.CodeCodingProductType.Where(x => x.Del == 0).ToListAsync();

            //string json = JsonConvert.SerializeObject(list);

            //IList<CodeCodingProductTypeVM> pTypeList = JsonConvert.DeserializeObject<IList<CodeCodingProductTypeVM>>(json);

            //return pTypeList;
        }

        public async Task<CodeCodingProductTypeVM> GetProductTypeByID(int Id, int CompanyId)
        {
            try 
            {
                CodeCodingProductTypeVM pTypeObj = new CodeCodingProductTypeVM();


                var mainPType = await this._context.CodeCodingProductType.Where(x => x.TypeID == Id && x.CompanyID == CompanyId).FirstOrDefaultAsync();

                var mainjson = JsonConvert.SerializeObject(mainPType);

                pTypeObj = JsonConvert.DeserializeObject<CodeCodingProductTypeVM>(mainjson);



                return pTypeObj;
            }
           
             catch (Exception ex)
            {

                throw new Exception("Get Product Type By ID Failed");
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
