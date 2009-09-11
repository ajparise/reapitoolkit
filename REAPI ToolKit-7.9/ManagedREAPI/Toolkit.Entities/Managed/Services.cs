using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public sealed class REServices : Blackbaud.PIA.RE7.BBREAPI.REServicesClass, IDisposable
    {
        Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext _sess;

        public REServices(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
            : base()
        {
            _sess = sess;
            this.Init(ref _sess);
        }

        public REServices()
            : base()
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            this.Init(ref _sess);
        }

        #region IDisposable Members

        public void Dispose()
        {
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.REServicesClass)this);
        }

        #endregion
    }
}
