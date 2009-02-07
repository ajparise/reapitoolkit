using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaisersEdge.API.ToolKit.Web.Services
{
    // NOTE: If you change the interface name "IREAPIService" here, you must also update the reference to "IREAPIService" in App.config.
    [ServiceContract]
    public interface ICodeTablesService
    {
        [OperationContract]
        List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseCodeTable> GetCodeTables();

        [OperationContract]
        List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry> GetCodeTableEntriesByTableName(string tableName);

        [OperationContract]
        List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry> GetCodeTableEntriesByTableID(int tableID);
        
        [OperationContract]
        bool UpdateCodeTableEntry(RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry entry);

        [OperationContract]
        bool DeleteCodeTableEntry(RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry entry);
    }
}
