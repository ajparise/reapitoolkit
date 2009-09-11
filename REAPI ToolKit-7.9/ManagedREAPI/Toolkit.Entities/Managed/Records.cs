using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public sealed class Records : Blackbaud.PIA.RE7.BBREAPI.CRecordsClass, IDisposable, Parise.RaisersEdge.Toolkit.Mapping.IMappingList
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext _sess;

        public Records(string clause, bool readOnly) : base()
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            base.Init(ref _sess, Blackbaud.PIA.RE7.BBREAPI.TopViewFilter_Record.tvf_record_CustomWhereClause, clause, true);
            base.SortField = Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_LAST_NAME;
            base.SortOrder = Blackbaud.PIA.RE7.BBREAPI.bbSortOrders.Ascending;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CRecordsClass)this);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IMappingList Members

        public IEnumerable<T> CopyInto<T>() where T : new()
        {
            return this.Cast<Blackbaud.PIA.RE7.BBREAPI._CRecord>().Select(record => new Parise.RaisersEdge.Toolkit.Mapping.Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CRecord>(record));
        }

        public IEnumerable<T> CopyInto<T>(IEnumerable<T> dataObjects)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> UpdateFrom<T>(IEnumerable<T> dataObjects)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
