using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RaisersEdge.API.ToolKit.Managed.Entities
{
    public class Record : Blackbaud.PIA.RE7.BBREAPI.CRecordClass, IDisposable, RaisersEdge.API.ToolKit.Managed.Mapping.IMapping
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess;

        #region Constructors

        public Record()
            : base()
        {
            try
            {
                sess = SingletonProxy.Instance.ManagedSessionContext;
                base.Init(ref sess);
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectCreationException("New Constituent Record", unknownEx);
            }
        }

        public Record(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
        {
            try
            {
                this.sess = sess;
                base.Init(ref this.sess);
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectCreationException("New Constituent Record", unknownEx);
            }
        }

        public Record(int sysID, bool readOnly)
            : base()
        {
            try
            {
                sess = SingletonProxy.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.Load(sysID, readOnly);
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", sysID.ToString(), "sysID", unknownEx);
            }
        }

        public Record(int sysID, bool readOnly, Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
            : base()
        {
            try
            {
                this.sess = sess;
                base.Init(ref sess);
                base.Load(sysID, readOnly);
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", sysID.ToString(), "sysID", unknownEx);
            }
        }

        public Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields field, object value, bool readOnly, Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
            : base()
        {
            try
            {
                this.sess = sess;
                base.Init(ref sess);
                base.LoadByField(field, value);
                base.ReadOnlyMode = readOnly;
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", (string)value, Enum.GetName(field.GetType(), field), unknownEx);
            }
        } 

        public Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields field, object value, bool readOnly)
            : base()
        {
            try
            {
                sess = SingletonProxy.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.LoadByField(field, value);
                base.ReadOnlyMode = readOnly;
            }
            catch (RaisersEdge.API.ToolKit.Managed.Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", (string)value, Enum.GetName(field.GetType(), field), unknownEx);
            }
        } 

        #endregion        

        #region Properties     

        public Blackbaud.PIA.RE7.BBREAPI.CConstitAddress PreferredAddressOrDefault
        {
            get
            {
                try
                {
                    return base.PreferredAddress;
                }
                catch
                {
                    return null;
                }
            }
        }
        
        #endregion

        public Blackbaud.PIA.RE7.BBREAPI.CIndividual Spouse
        {
            get
            {
                try
                {
                    return (Blackbaud.PIA.RE7.BBREAPI.CIndividual)base.Relations.Individuals().Spouse();
                }
                catch
                {
                    return null;
                }
            }
        }

        public T GetFieldValueAs<T>(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields field)
        {
            return (T)Convert.ChangeType(base.get_Fields(field), typeof(T));
        }

        #region IDisposable Members

        public void Dispose()
        {
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CRecordClass)this);
        }

        #endregion


        #region IMapping Members

        public T CopyInto<T>() where T : new()
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().CopyInto<T, Record>(this);
        }

        public T CopyInto<T>(T dataObject)
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().CopyInto<T, Record>(dataObject, this);
        }

        public T UpdateFrom<T>(T dataObject)
        {
            return new RaisersEdge.API.ToolKit.Managed.Mapping.Loader().UpdateFrom<T, Record>(dataObject, this);
        }

        #endregion
    }
}
