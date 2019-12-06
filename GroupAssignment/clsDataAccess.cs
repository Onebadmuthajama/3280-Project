using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace GroupAssignment {
    public class clsDataAccess {
        /// <summary>
        ///     Connection string to the database.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        ///     This method takes an SQL statement that is passed in and executes it.  The resulting values
        ///     are returned in a DataSet.  The number of rows reutrned from the query will be put into
        ///     the reference parameter returnValue
        /// </summary>
        /// <param name="sql"> The SQL statement to be executed </param>
        /// <returns> Returns a DataSet that contains the data from the SQL statement </returns>
        ///
        ///         private readonly string _connectionString;

        /// <summary>
        ///     Constructor that sets the connection string to the database
        /// </summary>
        public clsDataAccess() {
            _connectionString =
                $@"Provider=Microsoft.Jet.OLEDB.4.0; Data source={Directory.GetCurrentDirectory()}\\Invoice.mdb";
            //                $@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={Directory.GetCurrentDirectory()}\\ReservationSystem.mdb";
        }
        public DataSet ExecuteSqlStatement(string sql) {
            try {
                //Create a new DataSet
                var dataSet = new DataSet();

                using (var conn = new OleDbConnection(_connectionString))
                using (var adapter = new OleDbDataAdapter()) {
                    // Open the connect to the database
                    conn.Open();

                    // Add the information for the SelectCommand using the SQl statement and the connection object
                    adapter.SelectCommand = new OleDbCommand(sql, conn);
                    adapter.SelectCommand.CommandTimeout = 0;

                    // Fill up the DataSet with data
                    adapter.Fill(dataSet);
                }

                // Set the number of values returned

                // Return the Dataset
                return dataSet;
            }
            catch (Exception e) {
                throw new Exception($"DatabaseAccess.ExecuteSqlStatement encountered an error. - {sql} \n {e}");
            }
        }

        /// <summary>
        ///     This method takes an SQl statement that is passed in and executes it.  The resulting single value is returned
        /// </summary>
        /// <param name="sql"></param>
        /// <returns> The result of the executed SQL </returns>
        public string ExecuteScalarSql(string sql) {
            try {
                // Holds the return value
                object result;


                using (var conn = new OleDbConnection(_connectionString))
                using (var adapter = new OleDbDataAdapter()) {
                    // Open the connect to the database
                    conn.Open();

                    // Add the information for the SelectCommand using the SQl statement and the connection object
                    adapter.SelectCommand = new OleDbCommand(sql, conn);
                    adapter.SelectCommand.CommandTimeout = 0;

                    // Execute the scalar SQL statement
                    result = adapter.SelectCommand.ExecuteScalar();
                }

                return result == null ? "" : result.ToString();
            }
            catch (Exception e) {
                throw new Exception($"DatabaseAccess.ExecuteScalarSql encountered an error. - {sql} \n {e}");
            }
        }

        /// <summary>
        ///     This method takes an SQL statement that is a non query and executes it.
        /// </summary>
        /// <param name="sql"> The SQL statement to be executed </param>
        /// <returns> The number of rows effected </returns>
        public int ExecuteNonQuery(string sql) {
            try {
                // Holds the return value
                int result;

                using (var conn = new OleDbConnection(_connectionString)) {
                    // Open the connect to the database
                    conn.Open();

                    var cmd = new OleDbCommand(sql, conn);
                    cmd.CommandTimeout = 0;

                    result = cmd.ExecuteNonQuery();
                }

                return result;
            }
            catch (Exception e) {
                throw new Exception($"DatabaseAccess.ExecuteNonQuery encountered an error. - {sql} \n {e}");
            }
        }
    }
}