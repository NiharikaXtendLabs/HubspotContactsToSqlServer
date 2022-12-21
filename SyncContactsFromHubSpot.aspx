<%@ Page Language="C#" AutoEventWireup="true" Async="true"
    CodeBehind="SyncContactsFromHubSpot.aspx.cs" Inherits="HubspotContactsToSqlServer.SyncContactsFromHubSpot" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HubSpot Contacts</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:DataGrid ID="HubSpotContactsDataGrid" runat="server">
        </asp:DataGrid>
    </form>
</body>
</html>
