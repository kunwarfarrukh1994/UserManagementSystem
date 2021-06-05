using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SSMIS.DCL
{
    public class ConnectionManager
    {
        /// <summary>
        /// Get connection string from web.confiq file.
        /// </summary>
        /// <returns>connection string </returns>
        public static string GetConnectionString()
        {
            string connectionString = null;
            try
            {
                connectionString =ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
                /// As we don't have defined any exception methodology, therefore we are just throwoing the exception
            }
            finally
            {

            }
            return connectionString;
        }

        public static string GetConnectionStringWeb()
        {
            string connectionString = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringWeb"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
                /// As we don't have defined any exception methodology, therefore we are just throwoing the exception
            }
            finally
            {

            }
            return connectionString;
        }
        
        //used for Replication server
        public static string GetRptConnectionString()
        {
            string connectionString = null;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringReplication"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
                /// As we don't have defined any exception methodology, therefore we are just throwoing the exception
            }
            finally
            {

            }
            return connectionString;
        }


    }
}
