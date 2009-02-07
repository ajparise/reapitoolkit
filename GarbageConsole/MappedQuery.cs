using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleLinqIntegration
{
    public class AllMembersQueryRow
    {
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMapping("Member's Name")]
        public string MembersName { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMapping("Current Category")]
        public string CurrentCategory { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMapping(2)]
        public string AddedBy { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMapping(4)]
        public string CurrentLifetime { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMapping(5)]
        public string CurrentProgram { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.QueryMapping("Current Dues")]
        public Double CurrentDues { get; set; }
    }
}
