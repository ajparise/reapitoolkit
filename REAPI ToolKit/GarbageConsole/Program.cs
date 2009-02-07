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
            RaisersEdge.API.ToolKit.Managed.BaseProxy p = new RaisersEdge.API.ToolKit.Managed.BaseProxy(RESerial, RETestAccount, REPassword, DBNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);

            RaisersEdge.API.ToolKit.Managed.Entities.Query managedQuery = new RaisersEdge.API.ToolKit.Managed.Entities.Query("All Members");
            List <ExampleLinqIntegration.AllMembersQueryRow> result = managedQuery.LoadQuerySetInto<ExampleLinqIntegration.AllMembersQueryRow>();

            // Load an API Record
            RaisersEdge.API.ToolKit.Managed.Entities.Record apiRecord = new RaisersEdge.API.ToolKit.Managed.Entities.Record(Blackbaud.PIA.RE7.BBREAPI.bbRECORDUniqueFields.uf_Record_CONSTITUENT_ID, "3", false, p.SessionContext);

            // Copy data into our Custom Record Object
            GarbageConsole.Record mappedRecord = apiRecord.CopyInto<GarbageConsole.Record>();
            
            // Change some fields
            mappedRecord.FirstName = "ToolKit";
            mappedRecord.LastName = "Modifications";

            // Update the API object from the mapped object
            apiRecord.UpdateFrom<GarbageConsole.Record>(mappedRecord);

            // Save the record
            apiRecord.Save();

            p.Dispose();

        }
    }
}
