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
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly AppDbContext _context;
        DataTable dtCompanies;
        public CompaniesRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

        public void initDT()
        {
            dtCompanies = new DataTable();
            dtCompanies.Columns.Add("companyCode", typeof(string));
            dtCompanies.Columns.Add("companyTitle", typeof(string));
            dtCompanies.Columns.Add("businessNatureID", typeof(int));
            dtCompanies.Columns.Add("corporateLogin", typeof(string));
            dtCompanies.Columns.Add("corporatePWD", typeof(string));
            dtCompanies.Columns.Add("companyLogo", typeof(string));
            dtCompanies.Columns.Add("companySTN", typeof(string));
            dtCompanies.Columns.Add("companyNTN", typeof(string));
            dtCompanies.Columns.Add("companyAddress", typeof(string));
            dtCompanies.Columns.Add("companyPhone", typeof(string));
            dtCompanies.Columns.Add("isActive", typeof(int));


        }

        public async Task<string> SaveCompany(cdCompaniesVM company)
        {
            if (dtCompanies.Rows.Count > 0)
            {
                dtCompanies.Rows.Clear();
            }
            try
            {
                DataRow row = dtCompanies.NewRow();

            
                //row["companyCode"] = company.companyCode;
                row["companyTitle"] = company.companyTitle;
                row["businessNatureID"] = company.businessNatureID;
                row["corporateLogin"] = company.corporateLogin;
                row["corporatePWD"] = company.corporatePWD;
                row["companyLogo"] = company.companyLogo;
                row["companySTN"] = company.companySTN;
                row["companyNTN"] = company.companyNTN;
                row["companyAddress"] = company.companyAddress;
                row["companyPhone"] = company.companyPhone;
                row["isActive"] = company.isActive;



                dtCompanies.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {
                    
                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_Companies", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Company", SqlDbType.Structured).Value = dtCompanies;
                    cmd.Parameters.Add("@companyID", SqlDbType.BigInt).Value = company.companyID;



                    var returnParameter = cmd.Parameters.Add("@companyID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();


                    return "Company Saved Successfully for ID:" + result;



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }

        }

        public async Task<IList<cdCompaniesVM>> GetAllCompanies()
        {
            var list = await this._context.cdCompanies.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<cdCompaniesVM> companiesList = JsonConvert.DeserializeObject<IList<cdCompaniesVM>>(json);

            return companiesList;
        }

        public async Task<cdCompaniesVM> GetCompanyByID(int Id)
        {

            cdCompaniesVM compObj = new cdCompaniesVM();


            var mainComp = await this._context.cdCompanies.Where(x => x.companyID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainComp);

            compObj = JsonConvert.DeserializeObject<cdCompaniesVM>(mainjson);



            return compObj;
        }

        public async Task<string> DeleteCompany(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_Company", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@companyID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }

        }

        public async Task<cdCompaniesLookUpsVM> GetLookUpsforCompany()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@BNLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };


                var sql = "EXEC[CompanyGetSearchLookUps] @BNLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);



                cdCompaniesLookUpsVM lookups = new cdCompaniesLookUpsVM();



                lookups.cdcompaniesBN = JsonConvert.DeserializeObject<IList<cdCompaniesBNVM>>(@params[0].Value.ToString());
                



                con.Close();


                return lookups;



            }
        }



    }
}
