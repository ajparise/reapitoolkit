using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Parise.RaisersEdge.Toolkit.Mapping.DataContracts
{
    [DataContract]
    public class BaseTableEntry
    {
        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_ACTIVE, false, true)]
        public bool IsActive { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_CODETABLESID, true)]
        public int CodeTablesID { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_TABLEENTRIESID, true)]
        public int TableEntriesID { get; set; }

        //[DataMember]
        //[Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_INTEGRATION_ID, true)]
        //public int IntergrationID { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_LONGDESCRIPTION, false)]
        public string LongDescription { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_SHORTDESCRIPTION, false)]
        public string ShortDescription { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_DATECHANGED, true)]
        public DateTime DateLastChanged { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.TableEntryMapping(Blackbaud.PIA.RE7.RELibB.ETableEntryFields.tableentry_fld_LASTCHANGEDBYID, true)]
        public int LastChangedByID { get; set; }
    }

    [DataContract]
    public class BaseCodeTable
    {
        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.CodeTableMapping(Blackbaud.PIA.RE7.RELibB.ECodeTableFields.ctfNAME, true)]
        public string Name { get; set; }

        [DataMember]
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.CodeTableMapping(Blackbaud.PIA.RE7.RELibB.ECodeTableFields.ctfCODETABLEID, true)]
        public int ID { get; set; }

        [DataMember]
        public IEnumerable<BaseTableEntry> Entries { get; set; }
    }
}
