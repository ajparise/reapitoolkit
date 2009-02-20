using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parise.RaisersEdge.Toolkit.Entities.Managed
{
    /// <summary>
    /// Address Extensions
    /// </summary>
    public static class AddressExtensions
    {
        public static Blackbaud.PIA.RE7.BBREAPI._CConstitAddress PreferredAddressOrDefault(this Blackbaud.PIA.RE7.BBREAPI._CRecord entry)
        {
            try
            {
                return entry.PreferredAddress;
            }
            catch
            {
                return entry.Addresses.Cast<Blackbaud.PIA.RE7.BBREAPI._CConstitAddress>().FirstOrDefault();
            }
        }
    }
}
