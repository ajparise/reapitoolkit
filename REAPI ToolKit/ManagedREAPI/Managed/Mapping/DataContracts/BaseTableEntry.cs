using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RaisersEdge.API.ToolKit.Managed.Mapping.DataContracts
{
    [DataContract]
    public class BaseTableEntry
    {
        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_ACTIVE, false, true)]
        public bool IsActive { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_CODETABLESID, true)]
        public int CodeTablesID { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_TABLEENTRIESID, true)]
        public int TableEntriesID { get; set; }

        //[DataMember]
        //[RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_INTEGRATION_ID, true)]
        //public int IntergrationID { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_LONGDESCRIPTION, false)]
        public string LongDescription { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_SHORTDESCRIPTION, false)]
        public string ShortDescription { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_DATECHANGED, true)]
        public DateTime DateLastChanged { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_LASTCHANGEDBYID, true)]
        public int LastChangedByID { get; set; }
    }

    [DataContract]
    public class BaseCodeTable
    {
        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.CodeTableMapping(Blackbaud.PIA.RE7.RELibB.ECodeTableFields.ctfNAME, true)]
        public string Name { get; set; }

        [DataMember]
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.CodeTableMapping(Blackbaud.PIA.RE7.RELibB.ECodeTableFields.ctfCODETABLEID, true)]
        public int ID { get; set; }

        public IEnumerable<BaseTableEntry> Entries { get; set; }
    }
}
