using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginController
{
    public interface IUserManager
    {
        // TODO: add comments! when done
        bool ValidateUser(string username, string password);
        bool RegisterNewUser(User newUser);

    }
}
