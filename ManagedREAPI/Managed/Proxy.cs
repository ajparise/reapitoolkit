using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RaisersEdge.API.ToolKit.Managed
{
    public class BaseProxy : Blackbaud.PIA.RE7.BBREAPI.REAPIClass, IDisposable
    {
        private bool isConnected = false;
        public bool IsConnected
        {
            get { return isConnected; }
        }

        public BaseProxy() : base()
        {
            base.SignOutOnTerminate = true;
        }

        public BaseProxy(string reSerial, string accountName, string password, int dbNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode appMode) : base()
        {
            base.SignOutOnTerminate = true;
            ConnectAPI(reSerial, accountName, password, dbNumber, appMode);
        }

        #region API Connect/Disconnect
        public bool ConnectAPI(string reSerial, string accountName, string password, int dbNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode appMode)
        {            
            try
            {
                isConnected = base.Init(reSerial, accountName, password, dbNumber, "RaisersEdge.API.ToolKit", appMode);
                return isConnected;
            }
            catch (Exception err)
            {
                throw new InvalidOperationException("RE API failed to connect.\nAccount may already be logged on. Check the DB Connection Viewer Plugin.", err);
            }
        }
        #endregion

        #region Properties
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
                        throw new InvalidOperationException("Error getting session context - RE API was not initialized or failed to initialize.", err);
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            this.CloseDown();
        }
        #endregion
    }

    public static class SingletonProxy
    {
        #region Constants
        public readonly static string RESampleSerial = "WRE11111";
        public readonly static string RESampleAccountName = "Supervisor";
        public readonly static string RESampleAccountPassword = "admin";
        public readonly static int RESampleDatabaseNumber = 50;

        private static bool _useSampleDatabase = true;
        public static bool UseSampleDatabase
        {
            get { return SingletonProxy._useSampleDatabase; }
            set { SingletonProxy._useSampleDatabase = value; }
        }

        private static string _RESerial = "";
        public static string RESerial
        {
            get { return SingletonProxy._RESerial; }
            set { SingletonProxy._RESerial = value; }
        }

        private static string _REAccountName = "";
        public static string REAccountName
        {
            get { return SingletonProxy._REAccountName; }
            set { SingletonProxy._REAccountName = value; }
        }

        private static string _REAccountPassword = "";
        public static string REAccountPassword
        {
            get { return SingletonProxy._REAccountPassword; }
            set { SingletonProxy._REAccountPassword = value; }
        }
        
        private static int _REDatabaseNumber = 1;
        public static int REDatabaseNumber
        {
            get { return SingletonProxy._REDatabaseNumber; }
            set { SingletonProxy._REDatabaseNumber = value; }
        }

        #endregion

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static BaseProxy Instance
        {
            get
            {
                // Thread safe, lazy implementation of the singleton pattern.
                // See http://www.yoda.arachsys.com/csharp/singleton.html
                // for the full story.
                return SingletonInternal.instance;
            }
        }

        private class SingletonInternal
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit.
            static SingletonInternal()
            {
            }

            internal static readonly BaseProxy instance =
                    SingletonProxy.UseSampleDatabase ?
                        new BaseProxy(RESampleSerial, RESampleAccountName, RESampleAccountPassword, RESampleDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer)
                        :
                        new BaseProxy(_RESerial, _REAccountName, _REAccountPassword, _REDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);
        }
    }

}
