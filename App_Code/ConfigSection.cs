using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MB.TheBeerHouse
{
    public class TheBeerHouseSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultConnectionStringName", DefaultValue="LocalSqlServer")]
        public string DefaultConnectionStringName
        {
            get { return (string)base["defaultConnectionStringName"]; }
            set { base["defaultConnectionStringName"] = value; }
        }

        [ConfigurationProperty("defaultCacheDuration", DefaultValue = "600")]
        public int DefaultCacheDuration
        {
            get { return (int)base["defaultCacheDuration"]; }
            set { base["defaultCacheDuration"] = value; }
        }

        [ConfigurationProperty("contactForm", IsRequired=true)]
        public ContactFormElement ContactForm
        {
            get { return (ContactFormElement)base["contactForm"]; }            
        }
    }

    public class ContactFormElement : ConfigurationElement
    {
        [ConfigurationProperty("mailSubject", DefaultValue="Mail from TheBeerHouse: {0}")]
        public string MailSubject
        {
            get { return (string)base["mailSubject"]; }
            set { base["mailSubject"] = value; }
        }

        [ConfigurationProperty("mailTo", IsRequired=true)]
        public string MailTo
        {
            get { return (string)base["mailTo"]; }
            set { base["mailTo"] = value; }
        }

        [ConfigurationProperty("mailCC")]
        public string MailCC
        {
            get { return (string)base["mailCC"]; }
            set { base["mailCC"] = value; }
        }
    }
}