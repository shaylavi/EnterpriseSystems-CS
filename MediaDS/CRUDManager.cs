using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDS
{
    /// <summary>
    /// Dabase manager for Create / Read / Update / Delete actions
    /// </summary>
    class CRUDManager
    {

        DataSet results;
        string connString = string.Empty;
        string _sql = string.Empty;

        OleDbConnection conn;
        OleDbCommand sqlComm;

        OleDbDataAdapter oleAdapter;

        public CRUDManager()
        {
            connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            results = new DataSet();
        }
        private void OpenConnection()
        {
            try
            {
                conn = new OleDbConnection(connString);
                conn.Open();

            }
            catch (Exception e)
            {
                conn.Close();
                throw e;
            }
        }

        /// <summary>
        /// This function was designed to run CRUD operations in a generic way which supports all actions with all common data types (string / int / double)
        /// </summary>
        /// <param name="sqlStatement">SQL query</param>
        /// <param name="datasetName">Result's table name in case of select operation</param>
        /// <param name="sqlParam">Array of parameters if required</param>
        /// <returns></returns>
        public object ExecuteSqlStatement(string sqlStatement, string datasetName = "Table1", Dictionary<string, object> sqlParam = null)
        {
            int res = int.MinValue;

            try
            {
                results.Clear();

                _sql = sqlStatement;
                OpenConnection();

                sqlComm = new OleDbCommand(_sql, conn);
                sqlComm.CommandType = CommandType.Text;
                sqlComm.CommandText = _sql;
                if (sqlParam != null)
                {
                    foreach (var item in sqlParam)
                    {
                        sqlComm.Parameters.AddWithValue(item.Key, item.Value.ToString());
                    }
                }
                res = sqlComm.ExecuteNonQuery();

                if (sqlStatement.ToLower().Contains("select"))
                {
                    oleAdapter = new OleDbDataAdapter(_sql, conn);
                    oleAdapter.Fill(results, datasetName);
                    return results;
                }

                sqlComm.Dispose();
                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
            return res;
        }
    }
}
