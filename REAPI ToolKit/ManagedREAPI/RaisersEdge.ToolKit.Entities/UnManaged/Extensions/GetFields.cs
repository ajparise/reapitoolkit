using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaisersEdge.API.ToolKit.Managed
{
    public static class GetFieldExtensions
    {

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CQueryObject apiObj, Blackbaud.PIA.RE7.BBREAPI.EQUERIES2Fields field)
        {
            return (T)Convert.ChangeType(apiObj.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CGift apiObj, Blackbaud.PIA.RE7.BBREAPI.EGiftFields field)
        {
            return (T)Convert.ChangeType(apiObj.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CRecord apiObj, Blackbaud.PIA.RE7.BBREAPI.ERECORDSFields field)
        {
            return (T)Convert.ChangeType(apiObj.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI.IBBAttribute apiObj, Blackbaud.PIA.RE7.BBREAPI.EattributeFields field)
        {
            return (T)Convert.ChangeType(apiObj.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone data, Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESS_PHONEFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CEducation data, Blackbaud.PIA.RE7.BBREAPI.EEDUCATIONFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CIndividual data, Blackbaud.PIA.RE7.BBREAPI.EINDIVIDUALFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddress data, Blackbaud.PIA.RE7.BBREAPI.ECONSTIT_ADDRESSFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._COrganization data, Blackbaud.PIA.RE7.BBREAPI.EORGANIZATIONFIELDS field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CTableEntry data, Blackbaud.PIA.RE7.BBREAPI.ETableEntryFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable data, Blackbaud.PIA.RE7.BBREAPI.ECodeTableFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }

        public static T GetFieldValueAs<T>(this Blackbaud.PIA.RE7.BBREAPI.IBBNotepad data, Blackbaud.PIA.RE7.BBREAPI.ENotepadFields field)
        {
            return (T)Convert.ChangeType(data.get_Fields(field), typeof(T));
        }
    }
}
