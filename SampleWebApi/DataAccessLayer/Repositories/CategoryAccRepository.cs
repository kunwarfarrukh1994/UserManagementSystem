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
    public class CategoryAccRepository : ICategoryAccRepository
    {
        private readonly AppDbContext _context;
        DataTable dtCategory;
        public CategoryAccRepository(AppDbContext context)
        {
            this._context = context;
            initDT();
        }

      
        public void initDT()
        {
         
            dtCategory = new DataTable();
            
            dtCategory.Columns.Add("FinStatementTypeID", typeof(int));
            dtCategory.Columns.Add("compID", typeof(int));
            dtCategory.Columns.Add("Title", typeof(string));
            dtCategory.Columns.Add("TitleU", typeof(string));
            dtCategory.Columns.Add("Code", typeof(string));
            dtCategory.Columns.Add("BranchID", typeof(int));

        }

     

        public async Task<string> SaveCategoryAcc(adCategoryAccountsVM category)
        {
            if (dtCategory.Rows.Count > 0)
            {
                dtCategory.Rows.Clear();
            }
            try
            {
                var maxCode = "";
                if (category.compID == category.tmpCompID)
                {
                    maxCode = category.Code;
                }

                else
                {

                    maxCode = this._context.adCategoryAccounts.Where(x => x.compID == category.compID).Max(x => x.Code);

                    if (maxCode == null)
                    {
                        maxCode = "00";
                    }
                    int MC = Convert.ToInt32(maxCode.ToString()) + 1;
                    if (Convert.ToString(MC).Length == 1)
                        maxCode = "00" + MC.ToString();
                    else if(Convert.ToString(MC).Length == 2)
                        maxCode = "0" + MC.ToString();
                    else
                        maxCode = MC.ToString();

                }

                category.Code = maxCode;

                DataRow row = dtCategory.NewRow();

                
                row["FinStatementTypeID"] = category.FinStatementTypeID;
                row["compID"] = category.compID;
                row["Title"] = category.Title;
                row["TitleU"] = category.TitleU;
                row["Code"] = category.Code;
                row["BranchID"] = category.BranchID;
             



                dtCategory.Rows.InsertAt(row, 0);


                using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
                {

                    SqlCommand cmd = null;


                    cmd = new SqlCommand("dbo.Insert_CategoryAccounts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CategoryAcc", SqlDbType.Structured).Value = dtCategory;
                    cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = category.EDate;
                    cmd.Parameters.Add("@CateAccID", SqlDbType.BigInt).Value = category.CateAccID;



                    var returnParameter = cmd.Parameters.Add("@CateAccID", SqlDbType.BigInt);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    var result = returnParameter.Value;
                    con.Close();

                    return result.ToString();
                    //return "Category Saved Successfully for ID:" + result;



                }

            }
            catch (Exception ex)
            {

                throw new Exception("Insert Failed");
            }

        }


        public async Task<string> DeleteCategoryAcc(int Id)
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {

                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Del_CategoryAcc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CateAccID", SqlDbType.BigInt).Value = Id;

                con.Open();
                await cmd.ExecuteNonQueryAsync();

                con.Close();


                return "Record Deleted Successfully";



            }
        }

        public async Task<IList<adCategoryAccountsVM>> GetAllCategoriesAcc()
        {
            var list = await this._context.adCategoryAccounts.Where(x => x.Del == 0).ToListAsync();

            string json = JsonConvert.SerializeObject(list);

            IList<adCategoryAccountsVM> categoriesList = JsonConvert.DeserializeObject<IList<adCategoryAccountsVM>>(json);

            return categoriesList;
        }

        public async Task<adCategoryAccountsVM> GetCategoryAccByID(int Id)
        {
            adCategoryAccountsVM cateObj = new adCategoryAccountsVM();


            var mainComp = await this._context.adCategoryAccounts.Where(x => x.CateAccID == Id).FirstOrDefaultAsync();

            var mainjson = JsonConvert.SerializeObject(mainComp);

            cateObj = JsonConvert.DeserializeObject<adCategoryAccountsVM>(mainjson);



            return cateObj;
        }


        public async Task<adCategoryAccountsLookUpsVM> GetLookUpsforCategory()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@CompanyLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                      

                };


                var sql = "EXEC[GetSearchLookUpsCategoryAcc] @CompanyLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0]);



                adCategoryAccountsLookUpsVM lookups = new adCategoryAccountsLookUpsVM();



                lookups.adcategoryaccountscompanylookup = JsonConvert.DeserializeObject<IList<adCategoryAccountsCompanyLookUpVM>>(@params[0].Value.ToString());
                




                con.Close();


                return lookups;



            }
        }

    }
}
