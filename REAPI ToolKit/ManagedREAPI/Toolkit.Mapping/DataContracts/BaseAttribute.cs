using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Mapping.DataContracts
{
    public class BaseREAttribute
    {
        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_PARENTID)]
        public int ParentID { get; set; }

        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_ATTRIBUTEDATE)]
        public DateTime AttributeDate { get; set; }

        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_IMPORTID)]
        public string ImportID { get; set; }

        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_ATTRIBUTETYPES_ID)]
        public int AttributeTypesID { get; set; }

        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_ATTRIBUTES_ID)]
        public int AttributesID { get; set; }

        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_VALUE)]
        public string Value { get; set; }

        [Parise.RaisersEdge.Toolkit.Mapping.Attributes.AttributeMapping(Blackbaud.PIA.RE7.BBREAPI.EattributeFields.Attribute_fld_COMMENTS)]
        public string Comments { get; set; }
    }
}
