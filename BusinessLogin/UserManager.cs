using MediaDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    /// <summary>
    /// Controller to proxy requests for the data access layer for users data
    /// </summary>
    public class UserManager : IUserManager
    {
        UserDAO dal;
        public UserManager()
        {
            dal = new UserDAO();
        }

        /// <summary>
        /// Validate user details in the database. Return details as a customized DTO.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDTO ValidateUser(string username, string password)
        {
            MediaDS.UserDTO user = dal.ValidateUser(username, password);
            if (user != null)
            {
                UserDTO filteredUserData = new UserDTO(user.UserName, user.UserLevel, user.UserEmail);
                return filteredUserData;
            }
            else {
                return null;
            }
        }
    }
}
