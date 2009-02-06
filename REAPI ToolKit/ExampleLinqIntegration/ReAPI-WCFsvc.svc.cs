using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExampleLinqIntegration
{
    // NOTE: If you change the class name "ReAPI_WCFsvc" here, you must also update the reference to "ReAPI_WCFsvc" in Web.config.
    public class ReAPI_WCFsvc : IReAPI_WCFsvc
    {
        #region IReAPI_WCFsvc Members

        public DataContracts.Record GetConstituent(string constituentID)
        {
            if (!string.IsNullOrEmpty(constituentID))
            {
                RaisersEdge.API.ToolKit.Managed.Entities.Record record =
                    new RaisersEdge.API.ToolKit.Managed.Entities.Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields.uf_Record_CONSTITUENT_ID, constituentID, true);

                DataContracts.Record shallowCopy = record.CopyInto<DataContracts.Record>();

                record.Dispose();

                return shallowCopy;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateConstituent(DataContracts.Record updatedRecord)
        {
            RaisersEdge.API.ToolKit.Managed.Entities.Record record =
                new RaisersEdge.API.ToolKit.Managed.Entities.Record(updatedRecord.ID, false);

            record.UpdateFrom<DataContracts.Record>(updatedRecord);
            record.Save();
            record.Dispose();

            return true;
        }

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
        #endregion
    }
}
