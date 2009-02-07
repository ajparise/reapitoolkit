using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed.Mapping.DataContracts
{
    public class BaseREAttribute
    {
        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_PARENTID)]
        public int ParentID { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_ATTRIBUTEDATE)]
        public DateTime AttributeDate { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_IMPORTID)]
        public string ImportID { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_ATTRIBUTETYPES_ID)]
        public int AttributeTypesID { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_ATTRIBUTES_ID)]
        public int AttributesID { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_VALUE)]
        public string Value { get; set; }

        [RaisersEdge.API.ToolKit.Managed.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_COMMENTS)]
        public string Comments { get; set; }
    }
}
