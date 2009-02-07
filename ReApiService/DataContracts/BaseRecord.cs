using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RaisersEdge.API.ToolKit.Web.DataContracts
{
    [DataContract]
    public class BaseRecord
    {
        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_ID, true)]
        public int ID { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_CONSTITUENT_ID, true)]
        public string ConstituentID { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_FIRST_NAME)]
        public string FirstName { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_LAST_NAME)]
        public string LastName { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_MARITAL_STATUS)]
        public string MartialStatus { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_DATE_LAST_CHANGED, true)]
        public DateTime DateLastChanged { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_LAST_CHANGED_BY, true)]
        public string LastChangedBy { get; set; }
   }
}
