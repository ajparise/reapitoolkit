using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed
{
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
