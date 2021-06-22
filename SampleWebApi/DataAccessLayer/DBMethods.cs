using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
                    //if(inparams.SqlDbType == System.Data.SqlDbType.VarChar) 
                    //{
                    //    inparamsstr = inparamsstr + inparams.ParameterName + "='" + inparams.Value + "',";

                    //}
                    //else
                    //{

                    //    inparamsstr = inparamsstr + inparams.ParameterName + "=" + inparams.Value + ",";

                    //}
                    if (inparams.SqlDbType == System.Data.SqlDbType.VarChar)
                    {
                        inparamsstr = inparamsstr + "'" + inparams.Value + "',";

                    }
                    else
                    {

                        inparamsstr = inparamsstr  + inparams.Value + ",";

                    }
                    //EXEC[SalesGetSearchLookUps] @CustomerLookUp OUTPUT, @ItemLookUp OUTPUT, @PandiLookUp OUTPUT, @AddaLookUp OUTPUT;


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

        //public static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        //{
        //    command.Parameters.Clear();
        //    foreach (SqlParameter p in commandParameters)
        //    {
        //        if (p != null)
        //        {
        //            //check for derived output value with no value assigned
        //            if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output) && (p.Value == null))
        //            {
        //                p.Value = DBNull.Value;
        //            }

        //            command.Parameters.Add(p);
        //        }
        //    }
        //}
        //private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        //{
        //    //if the provided connection is not open, we will open it
        //    if (connection.State != ConnectionState.Open)
        //    {
        //        connection.Open();
        //    }

        //    command.CommandTimeout = 0;
        //    //associate the connection with the command
        //    command.Connection = connection;

        //    //set the command text (stored procedure name or SQL statement)
        //    command.CommandText = commandText;

        //    //if we were provided a transaction, assign it.
        //    if (transaction != null)
        //    {
        //        command.Transaction = transaction;
        //    }

        //    //set the command type
        //    command.CommandType = commandType;

        //    //attach the command parameters if they are provided
        //    if (commandParameters != null)
        //    {
        //        AttachParameters(command, commandParameters);
        //    }

        //    return;
        //}

        //public static DataTable ExecuteDataTable(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        //{

        //    //create a command and prepare it for execution
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        cmd.CommandTimeout = 0;
        //        PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters);

        //        //create the DataAdapter & DataSet
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        //fill the DataSet using default values for DataTable names, etc.

        //        da.Fill(dt);


        //        // detach the SqlParameters from the command object, so they can be used again.			
        //        cmd.Parameters.Clear();
        //        cmd.Connection.Close();
        //        cmd.Connection.Dispose();
        //        //return the dataset
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (cmd.Connection.State == ConnectionState.Open)
        //        {
        //            cmd.Connection.Close();
        //            cmd.Connection.Dispose();
        //        }
        //    }
        //}

        //public static DataTable ExecuteDataTable(string query, AppDbContext context)
        //{
        //    using (var sqlConnection = new SqlConnection(context.Database.GetConnectionString()))
        //    {
        //        try


        //        {

        //            sqlConnection.Open();

        //            DataTable dt = new DataTable();
        //            dt = ExecuteDataTable(sqlConnection, CommandType.Text, query);
        //            sqlConnection.Close();
        //            sqlConnection.Dispose();
        //            return dt;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            if (sqlConnection.State == ConnectionState.Open)
        //            {
        //                sqlConnection.Close();
        //                sqlConnection.Dispose();
        //            }
        //        }
        //    }
        //}

    }
}
