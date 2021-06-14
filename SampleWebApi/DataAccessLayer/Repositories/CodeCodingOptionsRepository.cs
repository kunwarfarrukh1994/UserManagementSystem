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
    public class CodeCodingOptionsRepository : ICodeCodingOptionsRepository
    {
        private readonly AppDbContext _context;
        DataTable dtOptions;
        public CodeCodingOptionsRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {

            dtOptions = new DataTable();
            dtOptions.Columns.Add("Title", typeof(string));
            dtOptions.Columns.Add("TitleU", typeof(string));
            dtOptions.Columns.Add("Notes", typeof(string));
            dtOptions.Columns.Add("CompanyID", typeof(int));
            dtOptions.Columns.Add("BranchID", typeof(int));
            dtOptions.Columns.Add("OperatorID", typeof(int));

        }

        public async Task<string> SaveOption(CodeCodingOptionsVM pOption)
        {
            if (dtOptions.Rows.Count > 0)
            {
                dtOptions.Rows.Clear();
            }
            try
            {
                DataRow row = dtOptions.NewRow();


                row["Title"] = pOption.Title;
                row["TitleU"] = pOption.TitleU;
                row["Notes"] = pOption.Notes;
                row["CompanyID"] = pOption.CompanyID;
                row["BranchID"] = pOption.BranchID;
                row["OperatorID"] = pOption.OperatorID;

                dtOptions.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_CodeCodingOptions", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@POption", SqlDbType.Structured).Value = dtOptions;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = pOption.EDate;
                    cmd.Parameters.Add("@OptionID", SqlDbType.BigInt).Value = pOption.OptionID;



                    var returnParameter = cmd.Parameters.Add("@OptionID", SqlDbType.BigInt);
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

        public async Task<string> DeleteOption(int Id)
        {
            try
            {
                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;

                    cmd = new SqlCommand("dbo.Del_CodeCodingOption", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OptionID", SqlDbType.BigInt).Value = Id;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();

                    con.Close();


                    return "Record Deleted Successfully";



                }
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed");
            }
        }






        public async Task<IList<CodeCodingOptionsVM>> GetAllOptions()
        {
            try
            {
                SqlParameter[] @outparams =
               {
                       new SqlParameter("@POptionLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},


                };
                SqlParameter[] @inparams =
                    {

                };
                await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_AllCodeCodingOptions", this._context);

                IList<CodeCodingOptionsVM> pOptions = JsonConvert.DeserializeObject<IList<CodeCodingOptionsVM>>(@outparams[0].Value.ToString());

                return pOptions;
            }
            catch (Exception ex)
            {

                throw new Exception("Get All Options Failed");
            }
        }

        public async Task<CodeCodingOptionsVM> GetOptionByID(int Id)
        {
            try
            {
                CodeCodingOptionsVM pOptionObj = new CodeCodingOptionsVM();


                var mainOption = await this._context.CodeCodingOptions.Where(x => x.OptionID == Id).FirstOrDefaultAsync();

                var mainjson = JsonConvert.SerializeObject(mainOption);

                pOptionObj = JsonConvert.DeserializeObject<CodeCodingOptionsVM>(mainjson);



                return pOptionObj;
            }

            catch (Exception ex)
            {

                throw new Exception("Get Product Category By ID Failed");
            }
        }

       
    }
}
