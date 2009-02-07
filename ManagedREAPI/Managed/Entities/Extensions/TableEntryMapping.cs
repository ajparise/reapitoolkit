using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed.Entities
{
    public static class MappingExtensions
    {
        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry) where T : new()
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry, T dataObject)
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry, T dataObject)
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable entry) where T : new()
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CCodeTable>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable entry, T dataObject)
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CCodeTable>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable entry, T dataObject)
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CCodeTable>(dataObject, entry);
        }
    }
}
