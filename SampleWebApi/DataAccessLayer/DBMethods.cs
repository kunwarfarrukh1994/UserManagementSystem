using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DBMethods
    {
        public static async Task<SqlParameter[]> EXECUTE_SP (SqlParameter[] in_params, SqlParameter[] out_params, string SPNAME, AppDbContext context)
        {
            //@ProcName = '<procedure name>'
            SPNAME = "EXEC[" + SPNAME + "]" + " ";
            string inparamsstr = "";
            string outparamsstr = "";

            if (in_params.Length > 0)
            {
                foreach (var inparams in in_params)
                {
                    
                    //EXEC[SalesGetSearchLookUps] @CustomerLookUp OUTPUT, @ItemLookUp OUTPUT, @PandiLookUp OUTPUT, @AddaLookUp OUTPUT;
                    inparamsstr = inparamsstr + inparams.ParameterName + "=" + inparams.Value + ",";
                }
                inparamsstr = inparamsstr.Remove(inparamsstr.Length - 1, 1);



            }

            if (out_params.Length > 0)
            {
                foreach (var outparam in out_params)
                {

                    //EXEC[SalesGetSearchLookUps] @CustomerLookUp OUTPUT, @ItemLookUp OUTPUT, @PandiLookUp OUTPUT, @AddaLookUp OUTPUT;
                    outparamsstr = outparamsstr + outparam.ParameterName + " OUTPUT ,";
                }

                outparamsstr = outparamsstr.Remove(outparamsstr.Length - 1, 1);



            }
            if (inparamsstr.Length > 0 && outparamsstr.Length > 0)
            {
                SPNAME = SPNAME + outparamsstr + "," + inparamsstr;
            }
            else if (inparamsstr.Length > 0 && outparamsstr.Length == 0)
            {
                SPNAME = SPNAME + inparamsstr;

            }
            else if (outparamsstr.Length > 0 && inparamsstr.Length == 0)
            {
                SPNAME = SPNAME + outparamsstr;

            }



            using (var con = new SqlConnection(context.Database.GetConnectionString()))
            {
                //,out_params[0], out_params[1], out_params[2], out_params[3]

                try
                {
                    await context.Database.ExecuteSqlRawAsync(SPNAME, out_params);

                    con.Close();
                    return out_params;

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

            // var s=JsonConvert.DeserializeObject<IList<SalePartyLookUp>>(out_params[0].Value.ToString());

        }



    }
}
