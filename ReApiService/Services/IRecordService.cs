using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaisersEdge.API.ToolKit.Web.Services
{
    // NOTE: If you change the interface name "IRecordServer" here, you must also update the reference to "IRecordServer" in App.config.
    [ServiceContract]
    public interface IRecordService
    {
        [OperationContract]
        RaisersEdge.API.ToolKit.Web.DataContracts.BaseRecord GetConstituent(string constituentID);

        [OperationContract]
        bool UpdateConstituent(RaisersEdge.API.ToolKit.Web.DataContracts.BaseRecord updatedRecord);
    }
}
