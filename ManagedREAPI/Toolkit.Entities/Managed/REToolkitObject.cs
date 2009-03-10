using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public class REToolkitObject
    {
        protected Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext _sessionContext;
        public REToolkitObject()
        {
            _sessionContext = RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
        }

        public REToolkitObject(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }
    }
}
