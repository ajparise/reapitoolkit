using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parise.RaisersEdge.Toolkit.Mapping;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    /// <summary>
    /// Extensions methods for REAPI object mapping
    /// Usage: apiObject.CopyInto<Mapped Class Type Name>
    /// Include the "Parise.RaisersEdge.Toolkit.Entities.Managed" namespace to get extensions
    /// </summary>
    public static class Mapping
    {
        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI.CTableEntry entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI.CTableEntry>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CCodeTable>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CCodeTable>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CCodeTable entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CCodeTable>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddress entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CConstitAddress>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddress entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CConstitAddress>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddress entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CConstitAddress>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CEducation entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CEducation>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CEducation entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CEducation>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CEducation entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CEducation>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.IBBNotepad entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.IBBNotepad>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.IBBNotepad entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.IBBNotepad>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI.IBBNotepad entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI.IBBNotepad>(dataObject, entry);
        }

        public static IEnumerable<T> CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI.IBBNotepadsAPI entry) where T : new()
        {
            return entry.Cast<Blackbaud.PIA.RE7.BBREAPI.IBBNotepad>().Select(n => new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI.IBBNotepad>(n));
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CIndividual entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CIndividual>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CIndividual entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CIndividual>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CIndividual entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CIndividual>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._COrganization entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._COrganization>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._COrganization entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._COrganization>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._COrganization entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._COrganization>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CConstitAddressPhone>(dataObject, entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CGift entry) where T : new()
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CGift>(entry);
        }

        public static T CopyInto<T>(this Blackbaud.PIA.RE7.BBREAPI._CGift entry, T dataObject)
        {
            return new Loader().CopyInto<T, Blackbaud.PIA.RE7.BBREAPI._CGift>(dataObject, entry);
        }

        public static T UpdateFrom<T>(this Blackbaud.PIA.RE7.BBREAPI._CGift entry, T dataObject)
        {
            return new Loader().UpdateFrom<T, Blackbaud.PIA.RE7.BBREAPI._CGift>(dataObject, entry);
        }
    }
}
