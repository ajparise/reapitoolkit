using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public static class BatchExtensions
    {
        public static T GetDataObjectAs<T>(this Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass tempRecord)
        {
            return (T)tempRecord.get_DataObject();
        }

        public static Blackbaud.PIA.RE7.BBREAPI._CGift GetDataObjectAsGift(this Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass tempRecord)
        {
            return (Blackbaud.PIA.RE7.BBREAPI._CGift)tempRecord.get_DataObject();
        }
    }
}
