using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsManager
{
    /// <summary>
    /// Customized exceptions class
    /// 
    /// </summary>
    [Serializable]
    public class DBConnectionException : Exception
    {
        public DBConnectionException()
        {
        }

        public DBConnectionException(string message) : base("The dataabase is unavailable: " + message)
        {
        }

    }


    [Serializable]
    public class DataValidationError : Exception
    {
        public DataValidationError() { }
        public DataValidationError(string message) : base(message) { }
        public DataValidationError(string message, Exception inner) : base(message, inner) { }
        protected DataValidationError(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
