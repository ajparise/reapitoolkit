using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Parise.RaisersEdge.Toolkit.Configuration
{
   public class ReApiToolkitSection : ConfigurationSection
    {
       private static ReApiToolkitSection settings
          = ConfigurationManager.GetSection("REAPIToolki") as ReApiToolkitSection;

       public static ReApiToolkitSection Settings
        {
            get
            {
                return settings;
            }
        }

       [ConfigurationProperty("defaultSingletonAccount", IsRequired = false)]
       public ProxyAccountElement DefaultSingletonProxyAccount
       {
           get
           {
               return (ProxyAccountElement)this["defaultSingletonAccount"];
           }
           set
           {
               this["defaultSingletonAccount"] = value;
           }
       }
    }

   public class ProxyAccountElement : ConfigurationElement
   {
       [ConfigurationProperty("useSampleDatabase", DefaultValue = true, IsRequired = true)]
       public Boolean UseSampleDatabase
       {
           get
           {
               return (Boolean)this["useSampleDatabase"];
           }
           set
           {
               this["useSampleDatabase"] = value;
           }
       }

       [ConfigurationProperty("accountName", DefaultValue = "Supervisor", IsRequired = true)]
       [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1)]
       public String AccountName
       {
           get
           {
               return (String)this["accountName"];
           }
           set
           {
               this["accountName"] = value;
           }
       }

       [ConfigurationProperty("accountPassword", DefaultValue = "admin", IsRequired = true)]
       [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1)]
       public String AccountPassword
       {
           get
           {
               return (String)this["accountPassword"];
           }
           set
           {
               this["accountPassword"] = value;
           }
       }

       [ConfigurationProperty("databaseNumber", DefaultValue = 50, IsRequired = true)]
       [IntegerValidator(ExcludeRange=false, MinValue=1,MaxValue=500)]
       public int DatabaseNumber
       {
           get
           {
               return (int)this["databaseNumber"];
           }
           set
           {
               this["databaseNumber"] = value;
           }
       }

       [ConfigurationProperty("appMode", DefaultValue = "Server", IsRequired = true)]
       public string AppMode
       {
           get
           {
               return (string)this["appMode"];
           }
           set
           {
               this["appMode"] = value;
           }
       }

       [ConfigurationProperty("serial", DefaultValue = "WRE11111", IsRequired = true)]
       public string Serial
       {
           get
           {
               return (string)this["serial"];
           }
           set
           {
               this["serial"] = value;
           }
       }
   }
}
