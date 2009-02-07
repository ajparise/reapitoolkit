using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RaisersEdge.API.ToolKit.Managed.Entities
{
    public class CodeTables : Blackbaud.PIA.RE7.BBREAPI.CCodeTablesClass, IDisposable, RaisersEdge.API.ToolKit.Managed.Mapping.IMappingList
    {
        private Dictionary<string, CodeTableEntries> _tableEntriesDict = new Dictionary<string, CodeTableEntries>();

        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess;

        public CodeTables()
            : base()
        {
            try
            {
                sess = SingletonProxy.Instance.ManagedSessionContext;
                base.Init(ref sess);
                foreach (Blackbaud.PIA.RE7.BBREAPI.CCodeTable codeTable in this)
                {
                    _codetables.Add(codeTable.GetFieldValueAs<string>(Blackbaud.PIA.RE7.BBREAPI.ECodeTableFields.ctfNAME), codeTable);
                }
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.ApiUnknownException(unknownEx);
            }
        }

        private Dictionary<string, Blackbaud.PIA.RE7.BBREAPI.CCodeTable> _codetables = new Dictionary<string, Blackbaud.PIA.RE7.BBREAPI.CCodeTable>();
        public Dictionary<string, Blackbaud.PIA.RE7.BBREAPI.CCodeTable> Tables
        {
            get
            {
                return _codetables;
            }
        }

        public CodeTableEntries this[string key]
        {
            get
            {
                if (!_tableEntriesDict.ContainsKey(key))
                {
                    KeyValuePair<int, string> table = TableNames.Where(t => t.Value.Equals(key)).FirstOrDefault();

                    if (!table.Equals(default(KeyValuePair<int, string>)))
                    {
                        _tableEntriesDict.Add(table.Value, new CodeTableEntries(table.Key));
                    }
                }
                return _tableEntriesDict[key];
            }
        }

        private Dictionary<int, string> tableNames;
        public Dictionary<int, string> TableNames
        {
            get
            {
                if (tableNames == null)
                {
                    tableNames = new Dictionary<int, string>();
                    foreach (Blackbaud.PIA.RE7.BBREAPI.CCodeTable codeTable in this)
                    {
                        tableNames.Add(codeTable.GetFieldValueAs<int>(Blackbaud.PIA.RE7.BBREAPI.ECodeTableFields.ctfCODETABLEID), codeTable.GetFieldValueAs<string>(Blackbaud.PIA.RE7.BBREAPI.ECodeTableFields.ctfNAME));
                    }
                }
                return tableNames;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _tableEntriesDict.Clear();
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CCodeTablesClass)this);
        }

        #endregion

        #region IMappingList Members

        public IEnumerable<T> CopyInto<T>() where T : new()
        {
            return Tables.Select(e => e.Value.CopyInto<T>());
        }

        public IEnumerable<T> CopyInto<T>(IEnumerable<T> dataObjects)
        {
            // Offset Negative or Zero - no adjustment needed (more dataObjects than entries)
            // Offset Positive - more entries than data objects - use offset
            int offset = Tables.Count - dataObjects.Count() > 0 ? Tables.Count - dataObjects.Count() : 0;

            var indexedDataObjects = dataObjects.ToArray();
            return Tables.Take(Tables.Count - offset).Select((e, i) => e.Value.CopyInto<T>(indexedDataObjects[i]));
        }

        public IEnumerable<T> UpdateFrom<T>(IEnumerable<T> dataObjects)
        {            
            // Offset Negative or Zero - no adjustment needed (more dataObjects than entries)
            // Offset Positive - more entries than data objects - use offset
            int offset = Tables.Count - dataObjects.Count() > 0 ? Tables.Count - dataObjects.Count() : 0;

            var indexedDataObjects = dataObjects.ToArray();
            return Tables.Take(Tables.Count - offset).Select((e, i) => e.Value.UpdateFrom<T>(indexedDataObjects[i]));
        }

        #endregion
    }
}
