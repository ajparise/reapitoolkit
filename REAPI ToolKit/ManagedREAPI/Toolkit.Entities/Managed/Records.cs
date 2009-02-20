using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public sealed class Records : Blackbaud.PIA.RE7.BBREAPI.CRecordsClass, IDisposable
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext _sess;

        public Records(string clause, bool readOnly) : base()
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            this.Init(ref _sess, Blackbaud.PIA.RE7.BBREAPI.TopViewFilter_Record.tvf_record_CustomWhereClause, clause, true); 
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CRecordsClass)this);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
