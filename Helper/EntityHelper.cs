using System.Collections.Generic;

namespace HubspotContactsToSqlServer.Helper
{
    public class HubSpotContacts
    {
        public List<Contact> Contacts;
    }
    public class Contact
    {
        public Properties Properties;
    }

    public class Properties
    {
        public FirstName FirstName;
        public LastName LastName;
    }
    public class FirstName
    {
        public string Value;

    }
    public class LastName
    {
        public string Value;
    }
}