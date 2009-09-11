using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parise.RaisersEdge.Toolkit.Mapping.Attributes;
using Parise.RaisersEdge.Toolkit.Entities.Managed;

namespace GarbageConsole
{
    public class FTFGift
    {
        [RecordMapping(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_ID, true)]
        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Constit_ID, false)]
        public int ConstituentSystemID { get; set; }

        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Fund, false)]
        public string Fund { get; set; }

        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Appeal, false)]
        public string Appeal { get; set; }

        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Amount, false)]
        public double ReceiptAmount { get; set; }

        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Receipt_Amount, false)]
        public double Amount { get; set; }

        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Type, false)]
        public string GiftType { get; set; }

        [GiftMapping(Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Payment_Type, false)]
        public string PaymentType { get; set; }

    }

    class Program
    {
        private static string RESerial = "WRE11111";
        private static string RETestAccount = "Supervisor";
        private static string REPassword = "admin";
        private static int DBNumber = 50;
        static void Main(string[] args)
        {
           // Records rs;

            //Array addressFields = Enum.GetValues(typeof(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESSFields));
            //foreach (Blackbaud.PIA.RE7.BBREAPI._CRecord person in people)
            //{
            //    foreach (Blackbaud.PIA.RE7.BBREAPI._CConstitAddress address in person.Addresses)
            //    {
            //        foreach(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESSFields addressField in addressFields)
            //        {
            //            Console.WriteLine(addressField.ToString() + ": " + (string)address.get_Fields(addressField));
            //        }
            //    }
            //}

            //Record r = new Record(583, true);
            //Console.WriteLine(r.get_Fields(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields.RECORDS_fld_CONSTITUENT_CODE));            
            //r.Dispose();
            //Console.ReadLine();
            //return;
            // Start the managed API Proxy
            //Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI p = new Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI(RESerial, RETestAccount, REPassword, DBNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);            

//            Parise.RaisersEdge.Toolkit.Entities.Managed.BatchAPI bapi = new 
            //    Parise.RaisersEdge.Toolkit.Entities.Managed.BatchAPI("Online FTF Test 3",
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_SolicitorNames,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Constit_ID,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Amount,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Receipt_Amount,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Type,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_GiftSubType,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Date,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Post_Date,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Post_Status,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Fund,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Campaign,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Appeal,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Package,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Payment_Type,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Anonymous,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Receipt_Flag,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Receipt_Date,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_Receipt_Number,
            //    Blackbaud.PIA.RE7.BBREAPI.EGiftFields.GIFT_fld_ConstituentBankId
            //    );

            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.UseSampleDatabase = false;
            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.REAccountName = "reapi service secondary";
            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.REAccountPassword = "raisers edge api integration";
            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.REDatabaseNumber = 1;
            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.RESerial = "RE7ASAREA301835";

            //Parise.RaisersEdge.Toolkit.Entities.Managed.BatchAPI bapi = new BatchAPI("Default CC");

            Parise.RaisersEdge.Toolkit.Entities.Managed.BatchAPI bapi = 
                new Parise.RaisersEdge.Toolkit.Entities.Managed.BatchAPI("ITS:::Default Copy Test", "Default CC");
            //bapi.Save();

            var fieldType = bapi.GiftFields;
            var bF = bapi.BFields;

            foreach (var f in fieldType)
            {
                Console.WriteLine(f.ToString());
            }

            foreach (Blackbaud.PIA.RE7.BBREAPI._CBatchField f in bF)
            {
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_BatchFieldId));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_BatchHeaderId));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_COLWIDTH));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_DefaultData));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_FieldName));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_FieldNumber));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_Hidden));
                Console.WriteLine(f.get_Fields(Blackbaud.PIA.RE7.BBREAPI.EBatchFieldFields.BatchField_fld_Sequence));
                Console.ReadLine();
            }

            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.Instance.CloseDown();
            //bapi.Save();
            //List<Blackbaud.PIA.RE7.BBREAPI._CTempRecord> gifts = bapi.Records.ToList();

            //foreach (Blackbaud.PIA.RE7.BBREAPI._CTempRecord gift in gifts)
            //{
            //    foreach (var field in bapi.GiftFields)
            //    {
            //        Console.WriteLine(field.ToString() + ": " + ((Blackbaud.PIA.RE7.BBREAPI._CGift)gift.get_DataObject()).get_Fields(field) as string);
            //    }
            //}
            //Console.WriteLine("\nPress any key to continue...");
            //Console.Read();

            //var temp = bapi.AddGift();
            //Blackbaud.PIA.RE7.BBREAPI._CGift gift = temp.GetDataObjectAsGift();

            //gift.UpdateFrom<FTFGift>(new FTFGift { Appeal = "Membership Mailing", Fund = "2008 Annual Fund", ConstituentSystemID = 128, GiftType = "Pledge", PaymentType = "Cash" });

            //object gu = (object)gift;
            //temp.set_DataObject(ref gu);
            ////temp.Save();
            ////Blackbaud.PIA.RE7.BBREAPI.CTempRecordClass gift = bapi.Records.Last();

            ////object tempupdate = ((Blackbaud.PIA.RE7.BBREAPI.CTempRecords)bapi.TempRecords).UpdateBatchTempWithTempRecords();
            ////Console.WriteLine(tempupdate.GetType().Name);

            //foreach (var field in bapi.GiftFields)
            //{
            //    Console.WriteLine(field.ToString() + ": " + gift.get_Fields(field) as string);
            //}

            //bapi.ManagedSave();
            //Console.Read();

            ////bapi.Save();
            ////bapi.Delete();
            //bapi.Dispose();
            ////RaisersEdge.API.ToolKit.Managed.Entities.BaseAPIListener list = new RaisersEdge.API.ToolKit.Managed.Entities.BaseAPIListener(p.ManagedSessionContext);
            ////list.__CAPIListener_Event_ObjectEvent += new Blackbaud.PIA.RE7.BBREAPI.__CAPIListener_ObjectEventEventHandler(list___CAPIListener_Event_ObjectEvent);
            ////list.CallBack.OnBBObjectEvent += new RaisersEdge.API.ToolKit.Managed.Entities.APICallback.BlackbaudObjectEvent(CallBack_OnBBObjectEvent);
            ////// Load an API Record
            ////RaisersEdge.API.ToolKit.Managed.Entities.Record apiRecord = new RaisersEdge.API.ToolKit.Managed.Entities.Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields.uf_Record_CONSTITUENT_ID, "3", false, p.SessionContext);

            ////// Copy data into our Custom Record Object
            ////GarbageConsole.Record mappedRecord = apiRecord.CopyInto<GarbageConsole.Record>();
            
            ////// Change some fields
            ////mappedRecord.FirstName = "ToolKit";
            ////mappedRecord.LastName = "Modifications";

            ////// Update the API object from the mapped object
            ////apiRecord.UpdateFrom<GarbageConsole.Record>(mappedRecord);

            ////// Save the record
            ////apiRecord.ManagedSave();

            ////p.Dispose();
            //Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.Instance.Dispose();
        }


    }
}
