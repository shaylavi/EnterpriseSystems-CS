using ExceptionsManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDS
{
    /// <summary>
    /// Proxy the actions against the database to specific actions for the users data
    /// </summary>
    public class UserDAO
    {
        CRUDManager crud;
        public UserDAO()
        {
            crud = new CRUDManager();
        }

        /// <summary>
        /// Validate login request and return the user's details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO ValidateUser(string username, string password)
        {
            try
            {
                DataSet userDetails = (DataSet)crud.ExecuteSqlStatement(string.Format("SELECT * FROM TABUSER WHERE username = '{0}' AND password = '{1}'", username, password), "UserDetails");

                if (userDetails.Tables["UserDetails"].Rows.Count > 0)
                {
                    foreach (DataRow row in userDetails.Tables["UserDetails"].Rows)
                    {
                        if (row["username"].ToString() == username && row["password"].ToString() == password)
                            return new UserDTO(row["username"].ToString(), row["userlevel"].ToString(), row["useremail"].ToString());
                    }
                }
                else throw new DataValidationError("Wrong details.. ");
            }
            catch (DataValidationError e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DBConnectionException(e.Message);
            }

            return null;
        }
    }
}
