using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed.Exceptions
{
    public class ApiUnknownException : System.Exception
    {
        public ApiUnknownException(System.Exception innerException) : base("Api encountered an unknown error - " + innerException.Message, innerException)
        {
        }
    }

    public class REObjectNotFoundException : System.ArgumentException
    {
        public REObjectNotFoundException(string objectName, string value, string paramName)
            : base(string.Format("{0} with {1} = {2} was not found", objectName, paramName, value), paramName)
        {
        }

        public REObjectNotFoundException(string objectName, string value, string paramName, System.Exception innerException)
            : base(string.Format("{0} with {1} = {2} was not found", objectName, paramName, value), paramName, innerException)
        {
        }
    }

    public class REObjectCreationException : System.Exception
    {
        public REObjectCreationException(string objectName)
            : base(string.Format("Could not create new {0}.", objectName))
        {
        }

        public REObjectCreationException(string objectName, System.Exception innerException)
            : base(string.Format("Could not create new {0}.", innerException))
        {
        }
    }

    public class ApiInitializationException : System.ArgumentException
    {
        public ApiInitializationException(System.Exception innerException) : base("Api is not initialized or failed to initialize - " + innerException.Message, innerException)
        {
        }
    }
}
