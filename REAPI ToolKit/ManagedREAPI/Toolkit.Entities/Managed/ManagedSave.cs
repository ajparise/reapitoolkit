using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    [DataContract]
    public class ManagedSaveResult
    {
        public enum SaveResult
        {
            ReadOnly = Blackbaud.PIA.RE7.BBREAPI.bbCantSaveReasons.csrObjectInReadOnlyMode,
            Locked = Blackbaud.PIA.RE7.BBREAPI.bbCantSaveReasons.csrRecordIsLocked,
            Security = Blackbaud.PIA.RE7.BBREAPI.bbCantSaveReasons.csrSecurity,
            UnknownFailure = -2,
            Saved = -1
        }

        [DataMember]
        public bool WasSaved
        {
            get;
            private set;
        }

        [DataMember]
        public SaveResult Result
        {
            get;
            private set;
        }

        [DataMember]
        public string Message
        {
            get;
            private set;
        }

        private ManagedSaveResult() { }

        internal ManagedSaveResult(bool wasSaved, Blackbaud.PIA.RE7.BBREAPI.bbCantSaveReasons result, string message)
        {
            WasSaved = wasSaved;
            Result = wasSaved ? SaveResult.Saved : (SaveResult)result;
            Message = message;
        }

        internal ManagedSaveResult(bool wasSaved, ManagedSaveResult.SaveResult result, string message)
        {
            WasSaved = wasSaved;
            Result = wasSaved ? SaveResult.Saved : (SaveResult)result;
            Message = message;
        }
    }
}
