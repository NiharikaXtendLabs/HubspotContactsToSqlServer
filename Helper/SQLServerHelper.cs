using System;
using System.Data;
using System.Data.SqlClient;

namespace HubspotContactsToSqlServer.Helper
{
    /// <summary>
    /// Creating connection with sql server database
    /// </summary>
    public static class SqlServerHelper
    {
        private static SqlConnection EstablishConnection()
        {
            var conn = new SqlConnection();
            try
            {
                // using the constants as per the database credentials
                var connectionString = $"Server={Constants.SqlServerName};" +
                $"Database={Constants.SqlServerDatabase};" +
                $"User Id={Constants.SqlServerUserId};" +
                $"Password={Constants.SqlServerPassword};" +
                "Encrypt=False;" +
                "TrustServerCertificate=True;";

                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return conn;
        }
        
        /// <summary>
        /// Inserting data into the sql server database table
        /// </summary>
        /// <param name="sqlObject">deserealised data as sql object</param>
        public static void InsertDataToSqlServer(HubSpotContacts sqlObject)
        {
            //Open the connection
            SqlConnection conn = null;

            try
            {
                conn = EstablishConnection();
                var tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("FirstName", typeof(string)));
                tbl.Columns.Add(new DataColumn("LastName", typeof(string)));

                foreach (var param in sqlObject.Contacts)
                {
                    var dr = tbl.NewRow();
                    dr["FirstName"] = param.Properties.FirstName.Value;
                    dr["LastName"] = param.Properties.LastName.Value;

                    tbl.Rows.Add(dr);
                }

                var sqlBulkObj = new SqlBulkCopy(conn)
                {
                    //assign Destination table name  
                    BatchSize = Constants.SqlServerBulkBatchSize,
                    DestinationTableName = Constants.SqlServerTableName
                };

                sqlBulkObj.ColumnMappings.Add("FirstName", "FirstName");
                sqlBulkObj.ColumnMappings.Add("LastName", "LastName");

                sqlBulkObj.WriteToServer(tbl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (conn!=null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}