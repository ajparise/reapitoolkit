using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RaisersEdge.API.ToolKit.Web.DataContracts;
namespace RaisersEdge.API.ToolKit.Web.Services
{
    // NOTE: If you change the class name "RecordServer" here, you must also update the reference to "RecordServer" in App.config.
    public class RecordService : IRecordService
    {
        public RaisersEdge.API.ToolKit.Web.DataContracts.BaseRecord GetConstituent(string constituentID)
        {
            if (!string.IsNullOrEmpty(constituentID))
            {
                RaisersEdge.API.ToolKit.Managed.Entities.Record record =
                    new RaisersEdge.API.ToolKit.Managed.Entities.Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields.uf_Record_CONSTITUENT_ID, constituentID, true);

                BaseRecord shallowCopy = record.CopyInto<BaseRecord>();

                record.Dispose();

                return shallowCopy;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateConstituent(RaisersEdge.API.ToolKit.Web.DataContracts.BaseRecord updatedRecord)
        {
            RaisersEdge.API.ToolKit.Managed.Entities.Record record =
                new RaisersEdge.API.ToolKit.Managed.Entities.Record(updatedRecord.ID, false);

            record.UpdateFrom<BaseRecord>(updatedRecord);
            record.Save();
            record.Dispose();

            return true;
        }
    }
}
