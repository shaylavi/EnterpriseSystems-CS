using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UserValidation
{
    [ServiceContract]
    public interface UserValidationWS
    {
        [OperationContract]
        UserWSDTO ValidateUser(UserWSDTO userObject);
    }


    [DataContract]
    public class UserWSDTO
    {
        string errorMessage;
        string username;
        string email;
        string password;

        [DataMember]
        public string Username { get { return username; } set { username = value; } }

        [DataMember]
        public string Email { get { return email; } set { email = value; } }

        [DataMember]
        public string Password { get { return password; }  set { password = value; } }

        [DataMember]
        public string ErrorMessage { get { return errorMessage; } set { errorMessage = value; } }

    }
}
