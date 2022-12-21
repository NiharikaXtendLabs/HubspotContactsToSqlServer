# HubspotContactsToSqlServer

This project runs ASP.NET web application. 
The web application takes dummy contacts list from hubspot API via contacts API, show the data in a datagrid structure and stores them in SQL server as the backend.

Steps to run -
1. Import the project in Visual Studio 2022
2. Install the required packages 
3. Enter your hubspot access token in the file - Helper\Constants.cs
4. Enter your SQL database credentials in the file -  Helper\Constants.cs
3. Run the project


Screenshot of the DataGrid showing the Hubspot's contacts
![image](https://user-images.githubusercontent.com/121125272/208903093-73ffa459-35ae-433b-a5de-6bc95fa68898.png)


Screemshot of the saved contacts into SQL server
![image](https://user-images.githubusercontent.com/121125272/208905731-8573fc70-de42-4ea1-b6dc-e2c5d5429ee6.png)
