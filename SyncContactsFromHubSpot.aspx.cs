using Newtonsoft.Json;
using System;
using System.Data;
using HubspotContactsToSqlServer.Helper;

namespace HubspotContactsToSqlServer
{
    public partial class SyncContactsFromHubSpot : System.Web.UI.Page
    {
        private static string _contactsList;
        protected void Page_Load(object sender, EventArgs e)
        {
            var table = new DataTable();
            HubSpotContacts deserializedContacts = null;
            GetContactsList();
            if (_contactsList != null)
            {
                table.Columns.Add("First Name");
                table.Columns.Add("Last Name");

                deserializedContacts = JsonConvert.DeserializeObject<HubSpotContacts>(_contactsList);
            }

            //show data on web browser
            if (deserializedContacts != null)
            {
                foreach (var contactsLists in deserializedContacts.Contacts)
                {
                    var firstName = contactsLists.Properties.FirstName.Value;
                    var lastName = contactsLists.Properties.LastName.Value;
                    table.Rows.Add(firstName, lastName);
                }
            }
            HubSpotContactsDataGrid.DataSource = table;
            HubSpotContactsDataGrid.DataBind();

            //add data to sql server
            SqlServerHelper.InsertDataToSqlServer(deserializedContacts);
        }

        private static async void GetContactsList()
        {
            _contactsList = await HubSpotApiHandler.GetContactsFromHubSpot();
        }
    }
}