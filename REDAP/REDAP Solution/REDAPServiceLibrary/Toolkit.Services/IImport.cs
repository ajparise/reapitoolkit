using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Services
{
    // NOTE: If you change the interface name "IImport" here, you must also update the reference to "IImport" in App.config.
    [ServiceContract]
    public interface IImport
    {

        //bool DoImport(IEnumerable<Parise.RaisersEdge.Toolkit.Services.DataContracts.ImportField> fields
    }
}
