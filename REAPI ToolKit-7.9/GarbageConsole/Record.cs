using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbageConsole
{
    public class Record
    {
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_ID, true)]
        public int ID { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_CONSTITUENT_ID, true)]
        public string ConstituentID { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_FIRST_NAME)]
        public string FirstName { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_LAST_NAME)]
        public string LastName { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_MARITAL_STATUS)]
        public string MartialStatus { get; set; }
    }
}
