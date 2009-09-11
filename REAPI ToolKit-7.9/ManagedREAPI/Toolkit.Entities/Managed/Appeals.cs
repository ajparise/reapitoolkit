using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public class Appeals : Blackbaud.PIA.RE7.BBREAPI.CAppealsClass, IDisposable, Parise.RaisersEdge.Toolkit.Mapping.IMappingList
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess;
        public Appeals(Blackbaud.PIA.RE7.BBREAPI.TopViewFilter_Appeal filterType, bool readOnly)
            : base()
        {
            sess = Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;

            string emptyClause = string.Empty;
            
            base.Init(ref sess, filterType, true, ref emptyClause);
            base.SortField = Blackbaud.PIA.RE7.BBREAPI.EAPPEALFields.Appeal_fld_DESCRIPTION;
            base.SortOrder = Blackbaud.PIA.RE7.BBREAPI.bbSortOrders.Ascending;

        }
        #region IDisposable Members

        public void Dispose()
        {
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CAppealsClass)this);
            GC.SuppressFinalize((Blackbaud.PIA.RE7.BBREAPI.CAppealsClass)this);
        }

        #endregion

        #region IMappingList Members

        public IEnumerable<T> CopyInto<T>() where T : new()
        {
            Parise.RaisersEdge.Toolkit.Mapping.Loader l = new Parise.RaisersEdge.Toolkit.Mapping.Loader();
            return this.Cast<Blackbaud.PIA.RE7.BBREAPI._CAppeal>().Select(appeal => l.CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CAppeal>(appeal));
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
