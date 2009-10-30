using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Services.DataContracts
{
    public class ImportField
    {
        public IEnumerable<Parise.RaisersEdge.Toolkit.Mapping.Attributes.BaseMapAttribute> Attributes { get; set; }

        public object Value { get; set; }
    }
}
