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
    public class LedgerRepository : ILedgerRepository
    {
        private readonly AppDbContext _context;
        

        public LedgerRepository(AppDbContext context)
        {
            this._context = context;
        }

        public static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            command.Parameters.Clear();
            foreach (SqlParameter p in commandParameters)
            {
                if (p != null)
                {
                    //check for derived output value with no value assigned
                    if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output) && (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }

                    command.Parameters.Add(p);
                }
            }
        }
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            //if the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            command.CommandTimeout = 0;
            //associate the connection with the command
            command.Connection = connection;

            //set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            //if we were provided a transaction, assign it.
            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            //set the command type
            command.CommandType = commandType;

            //attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return;
        }

        public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {

            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandTimeout = 0;
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

                //create the DataAdapter & DataSet
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                //fill the DataSet using default values for DataTable names, etc.

                da.Fill(dt);


                // detach the SqlParameters from the command object, so they can be used again.			
                cmd.Parameters.Clear();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                //return the dataset
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                }
            }
        }

        public DataTable ExecuteDataTable(string query)
        {
            using (var sqlConnection = new SqlConnection(this._context.Database.GetConnectionString()))
            {
                try


                {

                    sqlConnection.Open();

                    DataTable dt = new DataTable();
                    dt = ExecuteDataTable(sqlConnection, CommandType.Text, query);
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }
            }
        }

        public async Task<LedgerLookUpVM> GetLedgerDetail(LedgerAllInputs ledInputs)
        {
            LedgerLookUpVM lookups = new LedgerLookUpVM();
            DataTable dt = new DataTable();
            //string qry = "exec rpt_Ledger 1,'01-01-2020','01-01-2022',4,'JVAC'";

            string qry = "exec rpt_Ledger " + ledInputs.accountCode + ",'" + ledInputs.fromDate.Date + "','" + ledInputs.toDate.Date + "'," + ledInputs.branchID + ",'" + ledInputs.lg_Type + "'";

            dt = ExecuteDataTable(qry);
            if (dt.Rows.Count > 0)
            {
                string json = dt.Rows[0][0].ToString();
                lookups.ledgeralllookup = JsonConvert.DeserializeObject<IList<LedgerAllLookUpVM>>(json);
            }



            else
            {
                lookups = new LedgerLookUpVM();
            }

            return lookups;

        }
        //public async Task<LedgerLookUpVM> GetLedgerDetail(int accCode, DateTime fDate, DateTime tDate, string lg_type, int branchId)
        //{
        //    LedgerLookUpVM lookups = new LedgerLookUpVM();
        //    DataTable dt = new DataTable();
        //    //string qry = "exec rpt_Ledger 1,'01-01-2020','01-01-2022',4,'JVAC'";

        //    string qry = "exec rpt_Ledger " + accCode + ",'" + fDate + "','" + tDate + "'," + lg_type + ",'" + branchId + "'";

        //    dt = ExecuteDataTable(qry);
        //    if (dt.Rows.Count > 0)
        //    {
        //        string json = dt.Rows[0][0].ToString();
        //        lookups.ledgeralllookup = JsonConvert.DeserializeObject<IList<LedgerAllLookUpVM>>(json);
        //    }



        //    else
        //    {
        //        lookups = new LedgerLookUpVM();
        //    }

        //    return lookups;

        //}




        public async Task<LedgerLookUpVM> GetLookUpsforLedger(int CompanyID, int BranchID)
        {
            SqlParameter[] @outparams =
                  {
                       new SqlParameter("@AccountsLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

                };
            SqlParameter[] @inparams =
                {
                    new SqlParameter("@CompanyID", CompanyID),
                    new SqlParameter("@BranchID", BranchID)

                };
            await DBMethods.EXECUTE_SP(@inparams, @outparams, "GetSearchLookUpsLedger", this._context);

            LedgerLookUpVM lookups = new LedgerLookUpVM();
            lookups.ledgeraccountslookup = JsonConvert.DeserializeObject<IList<LedgerAccountsLookUpVM>>(@outparams[0].Value.ToString());



            return lookups;
        }




    }
}

///    .................... TESTING CODE FOR STORED PROCEDURE FOR LEDGER.................../////////////////////




//using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
//{
//    //string CS = @"Data Source=CYBERSPACE\EAS;Initial Catalog=Vanya-bak;Persist Security Info=True;User ID=sa;Password=risay";
//    //SqlConnection cn = null;
//    SqlCommand cmd = null;

//    //cn = new SqlConnection(CS);


//    cmd = new SqlCommand("dbo.rpt_Ledger", con);
//    cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.Add("@LedgerLookUp", SqlDbType.NVarChar).Value = "";
//    cmd.Parameters.Add("@AccountCode", SqlDbType.BigInt).Value = accCode;
//    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fDate.Date;
//    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = tDate.Date;
//    cmd.Parameters.Add("@BranchID", SqlDbType.BigInt).Value = branchID;
//    cmd.Parameters.Add("@Lg_Type", SqlDbType.VarChar).Value = lg_Type;



//    var returnParameter = cmd.Parameters.Add("@LedgerLookUp", SqlDbType.NVarChar);
//    returnParameter.Direction = ParameterDirection.ReturnValue;

//    con.Open();
//    await cmd.ExecuteNonQueryAsync();
//    var result = returnParameter.Value.ToString();
//    con.Close();


//    return "sss";



//}


//SqlParameter[] @outparams =
//      {
//           new SqlParameter("@LedgerLookUp", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Output}

//    };

////SqlParameter parametr = new SqlParameter();
////parametr.ParameterName = "@AccountCode";
////parametr.SqlDbType = SqlDbType.NVarChar;
////parametr.Direction = ParameterDirection.Input;
////parametr.Value = accCode;


//SqlParameter[] @inparams =
//    {
//        //new SqlParameter("@AccountCode", SqlDbType.NVarChar,-1) {Direction = ParameterDirection.Input , Value = accCode},
//        //new SqlParameter("@FromDate", SqlDbType.Date,-1) {Direction = ParameterDirection.Input , Value = fDate},
//        //new SqlParameter("@ToDate", SqlDbType.Date,-1) {Direction = ParameterDirection.Input , Value = tDate},
//        //new SqlParameter("@BranchID", SqlDbType.BigInt,-1) {Direction = ParameterDirection.Input , Value = branchID},
//        //new SqlParameter("@Lg_Type", SqlDbType. VarChar,-1) {Direction = ParameterDirection.Input , Value = lg_Type}

//        new SqlParameter("@AccountCode", accCode),

//        new SqlParameter("@FromDate",fDate),
//        new SqlParameter("@ToDate", tDate),
//        new SqlParameter("@BranchID", branchID),
//        new SqlParameter("@Lg_Type", lg_Type)
//    };
//string SPNAME = "rpt_Ledger";

//SPNAME = "EXEC[" + SPNAME + "]" + " ";
//string inparamsstr = "";
//string outparamsstr = "";

//if (inparams.Length > 0)
//{
//    int i = 0;
//    foreach (var inp in inparams)
//    {
//        if (i == 1 || i == 2 || i == 4) 
//        {
//            inparamsstr = inparamsstr + inp.ParameterName + "=" +"'"+inp.Value+"'" + ",";

//        }
//        else 
//        {
//            inparamsstr = inparamsstr + inp.ParameterName + "=" + inp.Value + ",";

//        }

//        i++;
//        //EXEC[SalesGetSearchLookUps] @CustomerLookUp OUTPUT, @ItemLookUp OUTPUT, @PandiLookUp OUTPUT, @AddaLookUp OUTPUT;
//    }
//    inparamsstr = inparamsstr.Remove(inparamsstr.Length - 1, 1);
//}

//if (outparams.Length > 0)
//{
//    foreach (var outp in outparams)
//    {

//        //EXEC[SalesGetSearchLookUps] @CustomerLookUp OUTPUT, @ItemLookUp OUTPUT, @PandiLookUp OUTPUT, @AddaLookUp OUTPUT;
//        outparamsstr = outparamsstr + outp.ParameterName + " OUTPUT ,";
//    }

//    outparamsstr = outparamsstr.Remove(outparamsstr.Length - 1, 1);

//}

//SPNAME = SPNAME + outparamsstr + "," + inparamsstr;

//using (var con = new SqlConnection(this._context.Database.GetConnectionString()))
//{
//    //,out_params[0], out_params[1], out_params[2], out_params[3]

//    try
//    {

//        //var sql = "EXEC[rpt_Ledger] @LedgerLookUp OUTPUT,@AccountCode, @FromDate, @ToDate, @BranchID, @Lg_Type; ";
//        //await this._context.Database.ExecuteSqlRawAsync(sql, outparams[0], accCode,fDate,tDate,branchID,lg_Type);

//        await this._context.Database.ExecuteSqlRawAsync(SPNAME, outparams);

//        con.Close();

//        //LedgerLookUpVM lookups = new LedgerLookUpVM();

//        //lookups.ledgeralllookup = JsonConvert.DeserializeObject<IList<LedgerAllLookUpVM>>(@outparams[0].Value.ToString());



//        return "";


//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }


//}


//await DBMethods.EXECUTE_SP(@inparams, @outparams, "rpt_Ledger", this._context);

//LedgerLookUpVM lookups = new LedgerLookUpVM();
//lookups.ledgeralllookup = JsonConvert.DeserializeObject<IList<LedgerAllLookUpVM>>(@outparams[0].Value.ToString());



//return "";