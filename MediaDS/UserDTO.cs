using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDS
{
    /// <summary>
    /// Data Transfer Object for user details
    /// </summary>
    public class UserDTO
    {
        public string UserName { get; set; }
        public string UserLevel { get; set; }
        public string UserEmail { get; set; }

        public UserDTO(string userName, string userLevel, string userEmail)
        {
            this.UserName = userName;
            this.UserLevel = userLevel;
            this.UserEmail = userEmail;
        }
    }
}
