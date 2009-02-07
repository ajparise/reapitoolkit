using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaisersEdge.API.ToolKit.Web.Services
{
    // NOTE: If you change the interface name "IQueryService" here, you must also update the reference to "IQueryService" in App.config.
    [ServiceContract]
    public interface IQueryService
    {
        [OperationContract]
        System.Data.DataTable GetQueryResult(string queryName);

        [OperationContract]
        IEnumerable<object> GetCustomQueryResult<T>(string queryName) where T : new();
    }
}
