using BussinessModels.ViewModels;
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
    public class SubAccountsRepository : ISubAccountsRepository
    {
        private readonly AppDbContext _context;
        public SubAccountsRepository(AppDbContext context)
        {
            this._context = context;
        }


        public async Task<adAccountsLookUpsVm> GetLookUpsforSubAccount()
        {
            using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                SqlParameter[] @params =
                    {
                       new SqlParameter("@AccTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@BalTypeLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@CtrlAccLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output},
                       new SqlParameter("@CityLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };


                var sql = "EXEC[SubAccountGetSearchLookUps] @AccTypeLookUp OUTPUT, @BalTypeLookUp OUTPUT, @CtrlAccLookUp OUTPUT, @CityLookUp OUTPUT; ";
                await this._context.Database.ExecuteSqlRawAsync(sql, @params[0], @params[1], @params[2], @params[3]);



                adAccountsLookUpsVm lookups = new adAccountsLookUpsVm();




                lookups.adaccountsacctypelookup = JsonConvert.DeserializeObject<IList<adAccountsAccTypeLookUpVM>>(@params[0].Value.ToString());
                lookups.adaccountsbaltypelookup = JsonConvert.DeserializeObject<IList<adAccountsBalTypeLookUpVM>>(@params[1].Value.ToString());
                lookups.adaccountsctrlacclookup = JsonConvert.DeserializeObject<IList<adAccountsCtrlAccLookUpVM>>(@params[2].Value.ToString());
                lookups.adaccountscitylookup = JsonConvert.DeserializeObject<IList<adAccountsCityLookUpVM>>(@params[3].Value.ToString());


                con.Close();


                return lookups;



            }
        }
    }
}
