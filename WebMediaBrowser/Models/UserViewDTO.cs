using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMediaBrowser.Models
{
    public class UserViewDTO
    {
        public UserViewDTO() { }
        public UserViewDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}