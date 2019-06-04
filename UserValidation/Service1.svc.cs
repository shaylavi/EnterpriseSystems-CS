using BusinessLogic;
using ExceptionsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserValidation
{
    public class Service1 : UserValidationWS
    {
        IUserManager userManager = new UserManager();

        public UserWSDTO ValidateUser(UserWSDTO userObject)
        {
            UserWSDTO user = new UserWSDTO();
            if (userObject == null || string.IsNullOrEmpty(userObject.Username) || string.IsNullOrEmpty(userObject.Password))
            {
                throw new ArgumentException("Invalid arguments");
            }

            try
            {
                if (userObject.Username != null && userObject.Password != null)
                {
                    BusinessLogic.UserDTO res = userManager.ValidateUser(userObject.Username, userObject.Password);
                    if (res != null)
                    {
                        user.Username = userObject.Username;
                        user.Email = userObject.Email;
                    }
                }
                else
                {
                    user.ErrorMessage = "No empty fields are allowed!";
                }
            }
            catch (DBConnectionException ex)
            {
                user.ErrorMessage = "Error connecting to the Database.";
                Console.WriteLine(ex.Message);
            }
            catch (DataValidationError ex)
            {
                user.ErrorMessage = ex.Message + "Please try again.";
            }

            return user;
        }
    }
}
