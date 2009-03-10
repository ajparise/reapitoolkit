using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    public class BatchAPI : Blackbaud.PIA.RE7.BBREAPI.CBatchAPIClass, IDisposable
    {        
        protected Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext _sess;

        public BatchAPI() : base() 
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            base.Init(_sess);
        }

        public BatchAPI(string batchNumber, params Blackbaud.PIA.RE7.BBREAPI.EGiftFields[] giftFields ) : base()
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            base.Init(_sess);
            base.set_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchAPIFields.BATCHAPI_fld_BATCH_NUMER, batchNumber);           

            foreach (Blackbaud.PIA.RE7.BBREAPI.EGiftFields field in giftFields)
            {
                AddGiftField(field);
            }
        }

       
        public BatchAPI(string batchNumber)
            : base()
        {
            _sess = Singleton.RaisersEdgeAPI.Instance.ManagedSessionContext;
            base.Init(_sess);
            base.LoadByNumber(batchNumber);
        }

        public Blackbaud.PIA.RE7.BBREAPI._CBatchFields BFields
        {
            get
            {
                return (Blackbaud.PIA.RE7.BBREAPI._CBatchFields)base.BatchFields;
            }
        }

        public void AddGiftField(Blackbaud.PIA.RE7.BBREAPI.EGiftFields fieldType)
        {
            Blackbaud.PIA.RE7.BBREAPI._CBatchField field = ((Blackbaud.PIA.RE7.BBREAPI._CBatchFields)base.BatchFields).Add();
            field.set_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_MetaObjectId, Blackbaud.PIA.RE7.BBREAPI.bbMetaObjects.bbmoGIFT);
            field.set_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_FieldNumber, fieldType);
        }

        public IEnumerable<Blackbaud.PIA.RE7.BBREAPI.EGiftFields> GiftFields
        {
            get
            {
                Type e = typeof(Blackbaud.PIA.RE7.BBREAPI.EGiftFields);
               return ((Blackbaud.PIA.RE7.BBREAPI._CBatchFields)base.BatchFields).Cast<Blackbaud.PIA.RE7.BBREAPI._CBatchField>()
                .Where(b => Enum.IsDefined(e, int.Parse(b.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_FieldNumber).ToString()))).Select
                    (b => (Blackbaud.PIA.RE7.BBREAPI.EGiftFields)int.Parse(b.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_FieldNumber).ToString()));
            }
        }

        public Blackbaud.PIA.RE7.BBREAPI.CTempRecords BatchTempRecords
        {
            get
            {
                return ((Blackbaud.PIA.RE7.BBREAPI.CTempRecords)TempRecords);
            }
        }

        public Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass AddGift()
        {
            //((Blackbaud.PIA.RE7.BBREAPI._CTempRecords)base.TempRecords).UpdateBatchTempWithTempRecords();

            Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass tempRecord = ((Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass)((Blackbaud.PIA.RE7.BBREAPI.CTempRecords)TempRecords).Add());            

            return tempRecord;
        }

        public Blackbaud.PIA.RE7.BBREAPI._CGift GetGift(int id)
        {
            return (Blackbaud.PIA.RE7.BBREAPI._CGift)
                ((Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass)((Blackbaud.PIA.RE7.BBREAPI._CTempRecords)TempRecords).Item(id)).get_DataObject();
        }

        public IEnumerable<Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass> Records
        {
            get
            {
                List<Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass> records = new List<Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass>();
                for(int i = 1; i < ((Blackbaud.PIA.RE7.BBREAPI._CTempRecords)TempRecords).Count(); i++)
                {
                    records.Add(((Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass)((Blackbaud.PIA.RE7.BBREAPI.CTempRecords)TempRecords).Item(i)));
                }

                return records.AsEnumerable();
            }
        }

        public ManagedSaveResult ManagedSave()
        {
            string deniedMsg = string.Empty;
            bool wasSaved = false;

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

            return new ManagedSaveResult(wasSaved, ManagedSaveResult.SaveResult.UnknownFailure, deniedMsg);
        }

        #region IDisposable Members

        public void Dispose()
        {
            base.CloseDown();
        }

        #endregion
    }
}
