﻿using BussinessModels.ViewModels;
using DataAccessLayer.ReposiotryInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            this._context = context;
        }
      
        public async Task<string> GetLogin(LoginVM login)
        {
            //SqlParameter[] @outparams =
            //  {
            //           new SqlParameter("@CompanyID", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},

            //    };
            //SqlParameter[] @inparams =
            //    {
            //        new SqlParameter("@CLogin", login.corporateLogin) {Direction = ParameterDirection.Input},
            //        new SqlParameter("@CPassword", login.corporatePWD) {Direction = ParameterDirection.Input},
            //    };
            //await DBMethods.EXECUTE_SP(@inparams, @outparams, "Get_Login", this._context);
            //string companyID = "";
            //companyID = @outparams[0].Value.ToString();
            ////lookups.salereturnmainlookup = JsonConvert.DeserializeObject<IList<SaleReturnMainLookUpVM>>(@outparams[0].Value.ToString());
            ////lookups.salereturnsublookup = JsonConvert.DeserializeObject<IList<SaleReturnSubLookUpVM>>(@outparams[1].Value.ToString());
            ////lookups.salereturngodownlookup = JsonConvert.DeserializeObject<IList<SaleReturnGodownLookUpVM>>(@outparams[2].Value.ToString());


            //return companyID;







            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlCommand cmd = null;

                cmd = new SqlCommand("dbo.Get_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CLogin", SqlDbType.VarChar).Value = login.corporateLogin;
                cmd.Parameters.Add("@CPassword", SqlDbType.VarChar).Value = login.corporatePWD;
                cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = "";


                var returnParameter = cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                var result = returnParameter.Value;
                con.Close();


                return result.ToString();



            }


        }
    }
}
