using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed.Mapping
{
    public interface IMapping
    {
        T CopyInto<T>() where T : new();

        T CopyInto<T>(T dataObject);

        T UpdateFrom<T>(T dataObject);
    }
}
