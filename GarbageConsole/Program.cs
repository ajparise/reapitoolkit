using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbageConsole
{
    class Program
    {
        private static string RESerial = "WRE11111";
        private static string RETestAccount = "Supervisor";
        private static string REPassword = "admin";
        private static int DBNumber = 50;
        static void Main(string[] args)
        {
            // Start the managed API Proxy
            //Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI p = new Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI(RESerial, RETestAccount, REPassword, DBNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);

            Parise.RaisersEdge.Toolkit.Entities.Managed.CodeTables c = new Parise.RaisersEdge.Toolkit.Entities.Managed.CodeTables();

            Parise.RaisersEdge.Toolkit.Entities.Managed.CodeTableEntries entries = c["Action Alert Title"];

            if (entries != null)
            {
                var test = entries.CopyInto<Parise.RaisersEdge.Toolkit.Mapping.DataContracts.BaseTableEntry>().ToList();
            }

            //RaisersEdge.API.ToolKit.Managed.Entities.BaseAPIListener list = new RaisersEdge.API.ToolKit.Managed.Entities.BaseAPIListener(p.ManagedSessionContext);
            //list.__CAPIListener_Event_ObjectEvent += new Blackbaud.PIA.RE7.BBREAPI.__CAPIListener_ObjectEventEventHandler(list___CAPIListener_Event_ObjectEvent);
            //list.CallBack.OnBBObjectEvent += new RaisersEdge.API.ToolKit.Managed.Entities.APICallback.BlackbaudObjectEvent(CallBack_OnBBObjectEvent);
            //// Load an API Record
            //RaisersEdge.API.ToolKit.Managed.Entities.Record apiRecord = new RaisersEdge.API.ToolKit.Managed.Entities.Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields.uf_Record_CONSTITUENT_ID, "3", false, p.SessionContext);

            //// Copy data into our Custom Record Object
            //GarbageConsole.Record mappedRecord = apiRecord.CopyInto<GarbageConsole.Record>();
            
            //// Change some fields
            //mappedRecord.FirstName = "ToolKit";
            //mappedRecord.LastName = "Modifications";

            //// Update the API object from the mapped object
            //apiRecord.UpdateFrom<GarbageConsole.Record>(mappedRecord);

            //// Save the record
            //apiRecord.ManagedSave();

            //p.Dispose();

            Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton.RaisersEdgeAPI.Instance.Dispose();
        }

        static void list___CAPIListener_Event_ObjectEvent(Blackbaud.PIA.RE7.BBREAPI.bbObjectEvents lObjectEvent, Blackbaud.PIA.RE7.BBREAPI.bbDataObjConstants lObjectType, Blackbaud.PIA.RE7.BBREAPI.IBBDataObject oDataObject, ref bool bCancel)
        {
            Console.WriteLine("CAPI Listener Event called");
        }

        static void CallBack_OnBBObjectEvent(Blackbaud.PIA.RE7.BBREAPI.bbObjectEvents lObjectEvent, Blackbaud.PIA.RE7.BBREAPI.bbDataObjConstants lObjectType, Blackbaud.PIA.RE7.BBREAPI.IBBDataObject oDataObject, ref bool bCancel)
        {
            Console.WriteLine("CallBack_OnBBObjectEvent Called");
        }

    }
}
