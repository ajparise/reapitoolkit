using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    /// <summary>
    /// .NET Managed version of the Blackbaud.PIA.RE7.BBREAPI.REAPIClass
    /// </summary>
    public sealed class RaisersEdgeAPI : Blackbaud.PIA.RE7.BBREAPI.REAPIClass, IDisposable
    {

        private bool isConnected;

        /// <summary>
        /// Indicates whether or not the API is connected
        /// </summary>
        public bool IsConnected
        {
            get { return isConnected; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RaisersEdgeAPI() : base()
        {
            base.SignOutOnTerminate = true;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="reSerial">RE Serial Number (Optional)</param>
        /// <param name="accountName">RE Account Name to Use</param>
        /// <param name="password">Password for specified account - NOT STORED</param>
        /// <param name="dbNumber">DB Number to connect to</param>
        /// <param name="appMode">AppMode - Server or Standalone</param>
        public RaisersEdgeAPI(string reSerial, string accountName, string password, int dbNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode appMode)
            : base()
        {
            base.SignOutOnTerminate = true;
            InitManaged(reSerial, accountName, password, dbNumber, appMode);
        }

        #region API Connect/Disconnect
        /// <summary>
        /// Managed API Initialization
        /// </summary>
        /// <param name="reSerial">RE Serial Number (Optional)</param>
        /// <param name="accountName">RE Account Name to Use</param>
        /// <param name="password">Password for specified account - NOT STORED</param>
        /// <param name="dbNumber">DB Number to connect to</param>
        /// <param name="appMode">AppMode - Server or Standalone</param>
        /// <returns>Value indicating success/failure</returns>
        public bool InitManaged(string reSerial, string accountName, string password, int dbNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode appMode)
        {            
            try
            {
                isConnected = base.Init(reSerial, accountName, password, dbNumber, "RaisersEdge.API.ToolKit", appMode);
                return isConnected;
            }
            catch (System.Runtime.InteropServices.COMException comError)
            {
                throw new Exceptions.ApiInitializationException(comError);
            }
            catch (System.Exception unknownError)
            {
                throw new Exceptions.ApiUnknownException(unknownError);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Managed Session Context
        /// </summary>
        public Blackbaud.PIA.RE7.BBREAPI.IBBSessionContext ManagedSessionContext
        {
            get
            {
                if (isConnected)
                {
                    try
                    {
                        return base.SessionContext;
                    }
                    catch (Exception err)
                    {
                        throw new Exceptions.SessionContextException(err);
                    }
                }
                else
                {
                    throw new Exceptions.ApiInitializationException(null);
                }
            }
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {            
            this.CloseDown();
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.REAPIClass)this);
            GC.SuppressFinalize(this);
        }
        #endregion
    }    

}
