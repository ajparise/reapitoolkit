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
                sess = Singleton<SingletonProxy>.Instance.ManagedSessionContext;
                base.Init(ref sess);
            }
            catch (System.Exception comError)
            {
                throw new Exception("Failed to initialize new record using singleton proxy.", comError);
            }
        }

        public Record(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
        {
            try
            {
                this.sess = sess;
                base.Init(ref this.sess);
            }
            catch (System.Exception comError)
            {
                throw new Exception("Failed to initialize new record.", comError);
            }
        }

        public Record(int sysID, bool readOnly)
            : base()
        {
            try
            {
                sess = Singleton<SingletonProxy>.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.Load(sysID, readOnly);
            }
            catch (System.Exception comError)
            {
                throw new Exception("Failed to initialize/load record " + sysID.ToString() + " using singleton proxy.", comError);
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
            catch (System.Exception comError)
            {
                throw new Exception("Failed to initialize/load record " + sysID.ToString(), comError);
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
            catch (System.Exception comError)
            {
                throw new Exception(
                    string.Format("Failed to initialize/load record as {0} using unique field \"{1}\" and value \"{2}\" using singleton proxy.",
                                    readOnly ? "read-only" : "writable",
                                    Enum.GetName(field.GetType(), field),
                                    (string)value), comError);
            }
        } 

        public Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields field, object value, bool readOnly)
            : base()
        {
            try
            {
                sess = Singleton<SingletonProxy>.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.LoadByField(field, value);
                base.ReadOnlyMode = readOnly;
            }
            catch (System.Exception comError)
            {
                throw new Exception(
                    string.Format("Failed to initialize/load record as {0} using unique field \"{1}\" and value \"{2}\" using singleton proxy.",
                                    readOnly ? "read-only" : "writable",
                                    Enum.GetName(field.GetType(), field),
                                    (string)value), comError);
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
            ProxyCleanUp.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CRecordClass)this);
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
