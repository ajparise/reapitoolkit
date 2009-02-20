using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Mapping
{
    public interface IMapping
    {
        T CopyInto<T>() where T : new();

        T CopyInto<T>(T dataObject);

        T UpdateFrom<T>(T dataObject);
    }    

    public interface IMappingList
    {
        IEnumerable<T> CopyInto<T>() where T : new();

        IEnumerable<T> CopyInto<T>(IEnumerable<T> dataObjects);

        IEnumerable<T> UpdateFrom<T>(IEnumerable<T> dataObjects);
    }
}
