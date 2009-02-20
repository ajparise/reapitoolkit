using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    /// <summary>
    /// Managed Funds class
    /// </summary>
    public class Funds : Blackbaud.PIA.RE7.BBREAPI.CFundsClass, IDisposable, Parise.RaisersEdge.Toolkit.Mapping.IMappingList
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess;
        public Funds(string customWhereClause, Blackbaud.PIA.RE7.BBREAPI.TopViewFilter_Fund filter, Blackbaud.PIA.RE7.BBREAPI.EfundFields sortField, Blackbaud.PIA.RE7.BBREAPI.bbSortOrders sortOrder, bool readOnly) : base()
        {
            sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            base.Init(ref sess, filter, readOnly, customWhereClause);
            base.SortField = sortField;
            base.SortOrder = sortOrder;
        }

        #region IMappingList Members

        public IEnumerable<T> CopyInto<T>() where T : new()
        {
            return this.Cast<Blackbaud.PIA.RE7.BBREAPI.IBBDataObject>().Select(fund => 
                new Parise.RaisersEdge.Toolkit.Mapping.Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.IBBDataObject>(fund));
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

        #region IDisposable Members

        public void Dispose()
        {
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CFundsClass)this);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
