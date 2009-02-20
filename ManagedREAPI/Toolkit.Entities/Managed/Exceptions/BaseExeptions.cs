using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed.Exceptions
{
    [Serializable]
    public class ApiUnknownException : System.Runtime.InteropServices.COMException
    {
        public ApiUnknownException(System.Exception innerException) : base("Api encountered an unknown error - " + innerException.Message, innerException)
        {
        }
    }

    [Serializable]
    public class REObjectNotFoundException : System.ArgumentException
    {
        public REObjectNotFoundException(string objectName, string value, string paramName)
            : base(string.Format(CultureInfo.InvariantCulture, "{0} with {1} = {2} was not found", objectName, paramName, value), paramName)
        {
        }

        public REObjectNotFoundException(string objectName, string value, string paramName, System.Exception innerException)
            : base(string.Format(CultureInfo.InvariantCulture, "{0} with {1} = {2} was not found", objectName, paramName, value), paramName, innerException)
        {
        }
    }

    [Serializable]
    public class REObjectCreationException : System.Runtime.InteropServices.COMException
    {
        public REObjectCreationException(string objectName)
            : base(string.Format(CultureInfo.InvariantCulture, "Could not create new {0}.", objectName))
        {
        }

        public REObjectCreationException(string objectName, System.Exception innerException)
            : base(string.Format(CultureInfo.InvariantCulture, "Could not create new {0}.", innerException))
        {
        }
    }

    [Serializable]
    public class ApiInitializationException : System.Runtime.InteropServices.COMException
    {
        public ApiInitializationException(System.Exception innerException) : base("Api is not initialized or failed to initialize - " + innerException.Message, innerException)
        {
        }
    }

    [Serializable]
    public class SessionContextException : System.InvalidOperationException
    {
        public SessionContextException(System.Exception innerException)
            : base("Failed to retrieve session context - " + innerException.Message, innerException)
        {
        }
    }
}
