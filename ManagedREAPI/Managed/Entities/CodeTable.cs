using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RaisersEdge.API.ToolKit.Managed.Entities
{
    public class CodeTableEntries : Blackbaud.PIA.RE7.BBREAPI.CTableEntriesClass, IDisposable, RaisersEdge.API.ToolKit.Managed.Mapping.IMappingList
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess;

        private int tableID;

        private Dictionary<string, Blackbaud.PIA.RE7.BBREAPI.CTableEntry> _entries = new Dictionary<string, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>();


        public CodeTableEntries(int tableID, ref Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
            : base()
        {
            try
            {
                this.sess = sess;
                this.tableID = tableID;
                base.Init(ref sess, this.tableID);
                foreach (Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry in this)
                {
                    _entries.Add(entry.GetFieldValueAs<string>(Blackbaud.PIA.RE7.BBREAPI.ETableEntryFields.tableentry_fld_TABLEENTRIESID), entry);
                }
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException("Code Table", tableID.ToString(), "TableID", unknownEx);
            }
        }

        public CodeTableEntries(int tableID)
            : base()
        {
            try
            {
                this.sess = SingletonProxy.Instance.ManagedSessionContext;
                this.tableID = tableID;
                base.Init(ref sess, this.tableID);

                foreach (Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry in this)
                {
                    _entries.Add(entry.GetFieldValueAs<string>(Blackbaud.PIA.RE7.BBREAPI.ETableEntryFields.tableentry_fld_TABLEENTRIESID), entry);
                }
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException("Code Table", tableID.ToString(), "TableID", unknownEx);
            }
        }

        public int ID
        {
            get
            {
                return this.tableID;
            }
        }

        public Blackbaud.PIA.RE7.BBREAPI.CTableEntry this[string tableEntryID]
        {
            get
            {
                if (_entries.ContainsKey(tableEntryID))
                {
                    return _entries[tableEntryID];
                }
                else
                {
                    return null;
                }
            }
        }

        public Dictionary<string, Blackbaud.PIA.RE7.BBREAPI.CTableEntry> Entries
        {
            get
            {
                return _entries;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _entries.Clear();
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CTableEntriesClass)this);
        }

        #endregion


        #region IMappingList Members

        public IEnumerable<T> CopyInto<T>() where T : new()
        {
            return _entries.Select(e => e.Value.CopyInto<T>());
        }

        public IEnumerable<T> CopyInto<T>(IEnumerable<T> dataObjects)
        {
            // Offset Negative or Zero - no adjustment needed (more dataObjects than entries)
            // Offset Positive - more entries than data objects - use offset
            int offset = _entries.Count - dataObjects.Count() > 0 ? _entries.Count - dataObjects.Count() : 0;

            var indexedDataObjects = dataObjects.ToArray();
            return _entries.Take(_entries.Count - offset).Select((e, i) => e.Value.CopyInto<T>(indexedDataObjects[i]));
        }

        public IEnumerable<T> UpdateFrom<T>(IEnumerable<T> dataObjects)
        {            
            // Offset Negative or Zero - no adjustment needed (more dataObjects than entries)
            // Offset Positive - more entries than data objects - use offset
            int offset = _entries.Count - dataObjects.Count() > 0 ? _entries.Count - dataObjects.Count() : 0;

            var indexedDataObjects = dataObjects.ToArray();
            return _entries.Take(_entries.Count - offset).Select((e, i) => e.Value.UpdateFrom<T>(indexedDataObjects[i]));
        }

        #endregion
    }
}
