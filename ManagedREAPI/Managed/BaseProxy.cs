﻿using System;
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
            System.Runtime.InteropServices.Marshal.ReleaseComObject((Blackbaud.PIA.RE7.BBREAPI.REAPIClass)this);
        }
        #endregion
    }    

}
