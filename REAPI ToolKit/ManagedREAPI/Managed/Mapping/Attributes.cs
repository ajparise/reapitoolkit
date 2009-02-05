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

        private bool _readOnly;
        public bool IsReadOnly { get { return _readOnly; } private set { } }
        protected BaseMapAttribute(object fieldToMap, bool readOnly)
        {
            _fieldToMap = fieldToMap;
            _fieldType = fieldToMap.GetType();
            _readOnly = readOnly;
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
    }


}
