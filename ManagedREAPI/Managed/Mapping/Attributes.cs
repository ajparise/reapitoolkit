using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed.Mapping.Attributes
{
    public class BaseMapAttribute : System.Attribute
    {
        private object _fieldToMap;
        public object FieldToMap { get { return _fieldToMap; } private set { } }
        
        private Type _fieldType;
        public Type FieldType { get { return _fieldType; } private set { } }

        private Type _valueType;
        public Type ValueTypeOverride { get; set; }

        private bool _readOnly;
        public bool IsReadOnly { get { return _readOnly; } private set { } }

        private bool _convertREBoolean = false;

        public bool IsREBoolean
        {
            get { return _convertREBoolean; }
            private set { }
        }

        protected BaseMapAttribute(object fieldToMap, bool readOnly)
        {
            _fieldToMap = fieldToMap;
            _fieldType = fieldToMap.GetType();
            _readOnly = readOnly;
        }

        protected BaseMapAttribute(object fieldToMap, bool readOnly, bool convertREBoolean)
        {
            _fieldToMap = fieldToMap;
            _fieldType = fieldToMap.GetType();
            _readOnly = readOnly;
            _convertREBoolean = convertREBoolean;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class QueryMappingAttribute : BaseMapAttribute
    {
        public QueryMappingAttribute(string columnName) : base(columnName, true)
        {
        }

        public QueryMappingAttribute(int columnIndex)
            : base(columnIndex, true)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RecordMappingAttribute : BaseMapAttribute
    {
        public RecordMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields fieldToMap) : base(fieldToMap, false)
        {
        }

        public RecordMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public RecordMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GiftMappingAttribute : BaseMapAttribute
    {
        public GiftMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftFields fieldToMap) : base(fieldToMap, false)
        {
        }

        public GiftMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftFields fieldToMap, bool readOnly) : base(fieldToMap, readOnly)
        {
        }

        public GiftMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ActonMappingAttribute : BaseMapAttribute
    {
        public ActonMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EACTIONFields fieldToMap) : base(fieldToMap, false)
        {
        }

        public ActonMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EACTIONFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public ActonMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EACTIONFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TableEntryMappingAttribute : BaseMapAttribute
    {
        public TableEntryMappingAttribute(Blackbaud.PIA.RE7.RELibB.ETableEntryFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public TableEntryMappingAttribute(Blackbaud.PIA.RE7.RELibB.ETableEntryFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public TableEntryMappingAttribute(Blackbaud.PIA.RE7.RELibB.ETableEntryFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AttributeMappingAttribute : BaseMapAttribute
    {
        public AttributeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EattributeFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public AttributeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EattributeFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public AttributeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EattributeFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CodeTableMappingAttribute : BaseMapAttribute
    {
        public CodeTableMappingAttribute(Blackbaud.PIA.RE7.RELibB.ECodeTableFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public CodeTableMappingAttribute(Blackbaud.PIA.RE7.RELibB.ECodeTableFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public CodeTableMappingAttribute(Blackbaud.PIA.RE7.RELibB.ECodeTableFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

}
