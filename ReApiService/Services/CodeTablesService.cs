using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RaisersEdge.API.ToolKit.Managed.Entities;

namespace RaisersEdge.API.ToolKit.Web.Services
{
    // NOTE: If you change the class name "REAPIService" here, you must also update the reference to "REAPIService" in App.config.
    public class CodeTablesService : ICodeTablesService
    {
        #region ICodeTablesService Members

        /// <summary>
        /// Gets all the code tables in raisers edge
        /// </summary>
        /// <returns>Serializable list of code tables</returns>
        public List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseCodeTable> GetCodeTables()
        {
            RaisersEdge.API.ToolKit.Managed.Entities.CodeTables c = new RaisersEdge.API.ToolKit.Managed.Entities.CodeTables();
            return c.CopyInto<RaisersEdge.API.ToolKit.Web.DataContracts.BaseCodeTable>().ToList();
        }

        /// <summary>
        /// Gets code table entries for a given table name
        /// </summary>
        /// <param name="tableName">Table name to retrieve code table entries from</param>
        /// <returns>Serializble list of code table entries</returns>
        public List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry> GetCodeTableEntriesByTableName(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                RaisersEdge.API.ToolKit.Managed.Entities.CodeTables c = new RaisersEdge.API.ToolKit.Managed.Entities.CodeTables();

                RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries entries = c[tableName];

                if (entries != null)
                {
                    return entries.CopyInto<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry>().ToList();
                }
            }

            // Return blank list if no table name is given or if it doesnt exist
            return new List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry>();
        }

        /// <summary>
        /// Gets code table entries for a given table name
        /// </summary>
        /// <param name="tableName">Table name to retrieve code table entries from</param>
        /// <returns>Serializble list of code table entries</returns>
        public List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry> GetCodeTableEntriesByTableID(int tableID)
        {
            try
            {
                RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries entries = new RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries(tableID);
                return entries.CopyInto<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry>().ToList();
            }
            catch(RaisersEdge.API.ToolKit.Managed.Exceptions.REObjectNotFoundException)
            {
                // Return blank list if bad table id
                return new List<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry>();
            }
        }

        /// <summary>
        /// Update an existing code table entry
        /// </summary>
        /// <param name="entry">Entry to update - must have TableEntriesID specified</param>
        /// <returns>Value indicating success</returns>
        public bool UpdateCodeTableEntry(RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry entry)
        {
            bool operationResult = true;

            RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries c = new RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries(entry.CodeTablesID);

            var apiEntry = c[entry.TableEntriesID.ToString()];

            if (apiEntry != null)
            {
                apiEntry.UpdateFrom<RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry>(entry);
                apiEntry.Save();
                apiEntry.CloseDown();
            }
            else
            {
                operationResult = false;
            }
            c.Dispose();

            return operationResult;
        }

        /// <summary>
        /// Delete an existing code table entry
        /// </summary>
        /// <param name="entry">Entry to delete, only TableEntriesID needs to be specified</param>
        /// <returns>Value indicating success</returns>
        public bool DeleteCodeTableEntry(RaisersEdge.API.ToolKit.Web.DataContracts.BaseTableEntry entry)
        {
            bool operationResult = true;

            RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries c = new RaisersEdge.API.ToolKit.Managed.Entities.CodeTableEntries(entry.CodeTablesID);

            var apiEntry = c[entry.TableEntriesID.ToString()];

            if (apiEntry != null)
            {
                apiEntry.Delete();
                apiEntry.Save();
                apiEntry.CloseDown();
            }
            else
            {
                operationResult = false;
            }
            c.Dispose();

            return operationResult;
        }

        #endregion
    }
}
