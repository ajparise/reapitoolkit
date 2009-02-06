using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExampleLinqIntegration
{
    // NOTE: If you change the interface name "IReAPI_WCFsvc" here, you must also update the reference to "IReAPI_WCFsvc" in Web.config.
    [ServiceContract]
    public interface IReAPI_WCFsvc
    {
        [OperationContract]
        DataContracts.Record GetConstituent(string constituentID);

        [OperationContract]
        bool UpdateConstituent(DataContracts.Record updatedRecord);

        [OperationContract]
        System.Data.DataTable GetQueryResult(string queryName);
    }
}
