using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    /// <summary>
    /// EXPERIMENTAL
    /// </summary>
    public class BaseAPIListener : APIListener<APICallback>
    {
        public BaseAPIListener() : base() { }
        public BaseAPIListener(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess) : base(sess) { }
    }

    /// <summary>
    /// EXPERIMENTAL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIListener<T> : Blackbaud.PIA.RE7.BBREAPI.CAPIListenerClass, IDisposable where T : Blackbaud.PIA.RE7.BBREAPI.IBBAPIListenerCallback, new()
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext _sess;
        private Blackbaud.PIA.RE7.BBREAPI.IBBAPIListenerCallback _callBack;

        public T CallBack
        {
            get { return (T)_callBack; }
        }

        public APIListener()
            : base()
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            _callBack = new T();
            this.Init(_sess, ref _callBack);
        }

        public APIListener(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
            : base()
        {
            _sess = sess;
            _callBack = new T();
            this.Init(_sess, ref _callBack);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CAPIListenerClass)this);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    /// <summary>
    /// EXPERIMENTAL
    /// </summary>
    public class APICallback : Blackbaud.PIA.RE7.BBREAPI.IBBAPIListenerCallback
    {
        #region IBBAPIListenerCallback Members
        public event BlackbaudMetaObjectEvent OnBBMetaObjectEvent;
        public delegate void BlackbaudMetaObjectEvent(Blackbaud.PIA.RE7.BBREAPI.bbObjectEvents lObjectEvent, Blackbaud.PIA.RE7.BBREAPI.bbMetaObjects lObjectType, Blackbaud.PIA.RE7.BBREAPI.IBBMetaField oMetaObject, ref bool bCancel);
        public void MetaObjectEvent(Blackbaud.PIA.RE7.BBREAPI.bbObjectEvents lObjectEvent, Blackbaud.PIA.RE7.BBREAPI.bbMetaObjects lObjectType, Blackbaud.PIA.RE7.BBREAPI.IBBMetaField oMetaObject, ref bool bCancel)
        {
            if (OnBBMetaObjectEvent != null)
            {
                OnBBMetaObjectEvent(lObjectEvent, lObjectType, oMetaObject, ref bCancel);
            }
        }

        public event BlackbaudObjectEvent OnBBObjectEvent;
        public delegate void BlackbaudObjectEvent(Blackbaud.PIA.RE7.BBREAPI.bbObjectEvents lObjectEvent, Blackbaud.PIA.RE7.BBREAPI.bbDataObjConstants lObjectType, Blackbaud.PIA.RE7.BBREAPI.IBBDataObject oDataObject, ref bool bCancel);
        public void ObjectEvent(Blackbaud.PIA.RE7.BBREAPI.bbObjectEvents lObjectEvent, Blackbaud.PIA.RE7.BBREAPI.bbDataObjConstants lObjectType, Blackbaud.PIA.RE7.BBREAPI.IBBDataObject oDataObject, ref bool bCancel)
        {
            if (OnBBObjectEvent != null)
            {
                OnBBObjectEvent(lObjectEvent, lObjectType, oDataObject, ref bCancel);
            }
        }

        #endregion
    }
}
