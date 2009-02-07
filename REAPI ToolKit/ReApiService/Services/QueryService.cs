using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaisersEdge.API.ToolKit.Web.Services
{
    // NOTE: If you change the class name "QueryService" here, you must also update the reference to "QueryService" in App.config.
    public class QueryService : IQueryService
    {
        public System.Data.DataTable GetQueryResult(string queryName)
        {
            if (!string.IsNullOrEmpty(queryName) && RaisersEdge.API.ToolKit.Managed.Entities.Query.QueryExists(queryName))
            {
                RaisersEdge.API.ToolKit.Managed.Entities.Query managedQuery = new RaisersEdge.API.ToolKit.Managed.Entities.Query(queryName);
                return managedQuery.OpenQuerySetAsDataTable();
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<object> GetCustomQueryResult<T>(string queryName) where T : new()
        {
            RaisersEdge.API.ToolKit.Managed.Entities.Query managedQuery = new RaisersEdge.API.ToolKit.Managed.Entities.Query(queryName);
            return managedQuery.LoadQuerySetInto<T>().Cast<object>();
        }
    }
}
