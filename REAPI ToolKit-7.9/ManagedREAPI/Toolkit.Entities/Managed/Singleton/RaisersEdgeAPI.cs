using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed.Singleton
{
    /// <summary>
    /// Static Singleton Implementation of Raisers Edge API
    /// Ensure at most ONE instance of Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI exists.
    /// </summary>
    public static class RaisersEdgeAPI
    {        
        #region Constants
        public readonly static string RESampleSerial = "WRE11111";
        public readonly static string RESampleAccountName = "Supervisor";
        public readonly static string RESampleAccountPassword = "admin";
        public readonly static int RESampleDatabaseNumber = 50;

        private static bool _useSampleDatabase = true;
        /// <summary>
        /// Specifies whether to connect using the sample database credentials or custom credentials
        /// </summary>
        public static bool UseSampleDatabase
        {
            get { return RaisersEdgeAPI._useSampleDatabase; }
            set { RaisersEdgeAPI._useSampleDatabase = value; }
        }

        private static string _RESerial = "";
        public static string RESerial
        {
            get { return RaisersEdgeAPI._RESerial; }
            set { RaisersEdgeAPI._RESerial = value; }
        }

        private static string _REAccountName = "";
        public static string REAccountName
        {
            get { return RaisersEdgeAPI._REAccountName; }
            set { RaisersEdgeAPI._REAccountName = value; }
        }

        private static string _REAccountPassword = "";
        public static string REAccountPassword
        {
            get { return RaisersEdgeAPI._REAccountPassword; }
            set { RaisersEdgeAPI._REAccountPassword = value; }
        }

        private static int _REDatabaseNumber = 1;
        public static int REDatabaseNumber
        {
            get { return RaisersEdgeAPI._REDatabaseNumber; }
            set { RaisersEdgeAPI._REDatabaseNumber = value; }
        }

        #endregion

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI Instance
        {
            get
            {
                // Thread safe, lazy implementation of the singleton pattern.
                // See http://www.yoda.arachsys.com/csharp/singleton.html
                // for the full story.
                return SingletonInternal.instance;
            }
        }

        public static void ReInitializeInstance()
        {
            SingletonInternal.reInitialize();
        }

        private class SingletonInternal
        {
            internal static void reInitialize()
            {
                if (instance != null)
                {
                    if (RaisersEdgeAPI.UseSampleDatabase)
                    {
                        instance.InitManaged(RESampleSerial, RESampleAccountName, RESampleAccountPassword, RESampleDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);
                    }
                    else
                    {
                        instance.InitManaged(_RESerial, _REAccountName, _REAccountPassword, _REDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);
                    }
                }
                else
                {
                    instance = RaisersEdgeAPI.UseSampleDatabase ?
                    new Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI(RESampleSerial, RESampleAccountName, RESampleAccountPassword, RESampleDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer)
                    :
                    new Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI(_RESerial, _REAccountName, _REAccountPassword, _REDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);
                }
            }

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit.
            static SingletonInternal()
            {
            }

            internal static Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI instance =
                    RaisersEdgeAPI.UseSampleDatabase ?
                        new Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI(RESampleSerial, RESampleAccountName, RESampleAccountPassword, RESampleDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer)
                        :
                        new Parise.RaisersEdge.Toolkit.Entities.Managed.RaisersEdgeAPI(_RESerial, _REAccountName, _REAccountPassword, _REDatabaseNumber, Blackbaud.PIA.RE7.BBREAPI.AppMode.amServer);
        }
    }
}
