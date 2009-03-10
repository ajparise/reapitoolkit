using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Mapping.Attributes
{
    public class BaseMapAttribute : System.Attribute
    {
        private object _fieldToMap;
        public object FieldToMap { get { return _fieldToMap; } }
        
        private Type _fieldType;
        public Type FieldType { get { return _fieldType; } }

        private bool _readOnly;
        public bool IsReadOnly { get { return _readOnly; } }

        private bool _convertREBoolean;
        public bool IsREBoolean
        {
            get { return _convertREBoolean; }
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
    public sealed class QueryMappingAttribute : BaseMapAttribute
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
    public sealed class RecordMappingAttribute : BaseMapAttribute
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
    public sealed class GiftMappingAttribute : BaseMapAttribute
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
    public sealed class ActonMappingAttribute : BaseMapAttribute
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
    public sealed class TableEntryMappingAttribute : BaseMapAttribute
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
    public sealed class AttributeMappingAttribute : BaseMapAttribute
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
    public sealed class CodeTableMappingAttribute : BaseMapAttribute
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

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class AddressMappingAttribute : BaseMapAttribute
    {
        public AddressMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESSFields fieldToMap) : base (fieldToMap, false)
        {
        }

        public AddressMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESSFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public AddressMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESSFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FundMappingAttribute : BaseMapAttribute
    {
        public FundMappingAttribute(Blackbaud.PIA.RE7.CFAData.EfundFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public FundMappingAttribute(Blackbaud.PIA.RE7.CFAData.EfundFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public FundMappingAttribute(Blackbaud.PIA.RE7.CFAData.EfundFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class EducationMappingAttribute : BaseMapAttribute
    {
        public EducationMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EEDUCATIONFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public EducationMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EEDUCATIONFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public EducationMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EEDUCATIONFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NotepadMappingAttribute : BaseMapAttribute
    {
        public NotepadMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ENotepadFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public NotepadMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ENotepadFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public NotepadMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ENotepadFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class IndividualMappingAttribute : BaseMapAttribute
    {
        public IndividualMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EINDIVIDUALFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public IndividualMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EINDIVIDUALFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public IndividualMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EINDIVIDUALFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class OrganizationMappingAttribute : BaseMapAttribute
    {
        public OrganizationMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EORGANIZATIONFIELDS fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public OrganizationMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EORGANIZATIONFIELDS fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public OrganizationMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EORGANIZATIONFIELDS fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class PhoneMappingAttribute : BaseMapAttribute
    {
        public PhoneMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESS_PHONEFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public PhoneMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESS_PHONEFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public PhoneMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESS_PHONEFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class AppealMappingAttribute : BaseMapAttribute
    {
        public AppealMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EAPPEALFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public AppealMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EAPPEALFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public AppealMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EAPPEALFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SoftCreditMappingAttribute : BaseMapAttribute
    {
        public SoftCreditMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftSoftCreditFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public SoftCreditMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftSoftCreditFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public SoftCreditMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftSoftCreditFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class TributeMappingAttribute : BaseMapAttribute
    {
        public TributeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftTributeFields fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public TributeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftTributeFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public TributeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftTributeFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class TributeAcknowledgeeMappingAttribute : BaseMapAttribute
    {
        public TributeAcknowledgeeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftTributeAcknowledgeeFields  fieldToMap)
            : base(fieldToMap, false)
        {
        }

        public TributeAcknowledgeeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftTributeAcknowledgeeFields fieldToMap, bool readOnly)
            : base(fieldToMap, readOnly)
        {
        }

        public TributeAcknowledgeeMappingAttribute(Blackbaud.PIA.RE7.BBREAPI.EGiftTributeAcknowledgeeFields fieldToMap, bool readOnly, bool convertREBoolean)
            : base(fieldToMap, readOnly, convertREBoolean)
        {
        }
    }

}
