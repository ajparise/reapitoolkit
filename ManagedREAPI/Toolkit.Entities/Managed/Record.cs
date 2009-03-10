using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Globalization;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public sealed class Record : Blackbaud.PIA.RE7.BBREAPI.CRecordClass, IDisposable, Parise.RaisersEdge.Toolkit.Mapping.IMapping
    {
        private Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess;

        #region Constructors

        public Record()
            : base()
        {
            try
            {
                sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.ReadOnlyMode = false;
            }
            catch (Exceptions.ApiInitializationException apiFail)
            {
                throw apiFail;
            }
            catch (System.Exception unknownEx)
            {
                throw new Exceptions.REObjectCreationException("New Constituent Record", unknownEx);
            }
        }

        public Record(Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext sess)
        {
            try
            {
                this.sess = sess;
                base.Init(ref this.sess);
            }
            catch (Exceptions.ApiInitializationException)
            {
                throw;
            }
            catch (System.Exception unknownEx)
            {
                throw new Exceptions.REObjectCreationException("New Constituent Record", unknownEx);
            }
        }

        public Record(int sysID, bool readOnly)
            : base()
        {
            try
            {
                sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.Load(sysID, readOnly);
            }
            catch (Exceptions.ApiInitializationException)
            {
                throw;
            }
            catch (System.Exception unknownEx)
            {
                throw new Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", sysID.ToString(), "sysID", unknownEx);
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
            catch (Exceptions.ApiInitializationException)
            {
                throw;
            }
            catch (System.Exception unknownEx)
            {
                throw new Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", sysID.ToString(), "sysID", unknownEx);
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
            catch (Exceptions.ApiInitializationException)
            {
                throw;
            }
            catch (System.Exception unknownEx)
            {
                throw new Exceptions.REObjectNotFoundException(readOnly ? "Read-Only " : "Writable " + "Constituent Record", (string)value, Enum.GetName(field.GetType(), field), unknownEx);
            }
        } 

        public Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields field, object value, bool readOnly)
            : base()
        {
            try
            {
                sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
                base.Init(ref sess);
                base.LoadByField(field, value);
                base.ReadOnlyMode = readOnly;
            }
            catch (Exceptions.ApiInitializationException)
            {
                throw;
            }
            catch (System.Exception unknownEx)
            {
                throw new Exceptions.REObjectNotFoundException((readOnly ? "Read-Only " : "Writable ") + "Constituent Record", (string)value, Enum.GetName(field.GetType(), field), unknownEx);
            }
        } 

        #endregion     

        public ManagedSaveResult ManagedSave()
        {
            Blackbaud.PIA.RE7.BBREAPI.bbCantSaveReasons deniedReason = Blackbaud.PIA.RE7.BBREAPI.bbCantSaveReasons.csrObjectInReadOnlyMode;
            string deniedMsg = string.Empty;

            bool canSave = this.CanBeSaved(ref deniedReason, ref deniedMsg);
            bool wasSaved = false;

            if (canSave)
            {
                try
                {
                    this.Save();
                    wasSaved = true;
                }
                catch (System.Runtime.InteropServices.COMException badSave)
                {
                    deniedMsg = badSave.Message + "\nStack Trace: " + badSave.StackTrace;
                    wasSaved = false;
                }
            }

            return new ManagedSaveResult(wasSaved, deniedReason, deniedMsg);
        }

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

        /// <summary>
        /// Returns individuals that match the relationship given
        /// </summary>
        /// <param name="relationCode">Relation Code</param>
        /// <param name="recipRelationCode">Reciprical Relation Code</param>
        /// <returns></returns>
        public IEnumerable<Blackbaud.PIA.RE7.BBREAPI._CIndividual> IndividualsByRelation(string relationCode, string recipRelationCode)
        {
            return base.Relations.Individuals().Cast<Blackbaud.PIA.RE7.BBREAPI._CIndividual>().Where
                (
                i => relationCode.Equals(i.GetFieldValueAs<string>(Blackbaud.PIA.RE7.BBREAPI.EINDIVIDUALFields.INDIVIDUAL_fld_RELATION_CODE), StringComparison.CurrentCultureIgnoreCase) &&
                     recipRelationCode.Equals(i.GetFieldValueAs<string>(Blackbaud.PIA.RE7.BBREAPI.EINDIVIDUALFields.INDIVIDUAL_fld_RECIP_RELATION_CODE), StringComparison.CurrentCultureIgnoreCase)
                );
        }

        public IEnumerable<Blackbaud.PIA.RE7.BBREAPI._CEducation> Educations
        {
            get
            {
                return base.Relations.Education().Cast<Blackbaud.PIA.RE7.BBREAPI._CEducation>();
            }
        }
        #endregion

        public Blackbaud.PIA.RE7.BBREAPI._CIndividual Spouse
        {
            get
            {
                try
                {
                    return (Blackbaud.PIA.RE7.BBREAPI._CIndividual)base.Relations.Individuals().Spouse();
                }
                catch
                {
                    return null;
                }
            }
        }

        public T GetFieldValueAs<T>(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields field)
        {
            return (T)Convert.ChangeType(base.get_Fields(field), typeof(T), CultureInfo.CurrentCulture);
        }

        #region IDisposable Members

        public void Dispose()
        {
            base.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.CRecordClass)this);
            GC.SuppressFinalize(this);
        }

        #endregion


        #region IMapping Members

        public T CopyInto<T>() where T : new()
        {
            return new Parise.RaisersEdge.Toolkit.Mapping.Loader().CopyInto<T, Record>(this);
        }

        public T CopyInto<T>(T dataObject)
        {
            return new Parise.RaisersEdge.Toolkit.Mapping.Loader().CopyInto<T, Record>(dataObject, this);
        }

        public T UpdateFrom<T>(T dataObject)
        {
            return new Parise.RaisersEdge.Toolkit.Mapping.Loader().UpdateFrom<T, Record>(dataObject, this);
        }

        #endregion
    }
}
