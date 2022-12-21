using System;
using System.Configuration;

namespace HubspotContactsToSqlServer.Helper
{
    public static class Constants
    {
        public static string SqlServerName = Convert.ToString(ConfigurationManager.AppSettings["SqlServerName"]);
        public static string SqlServerUserId = Convert.ToString(ConfigurationManager.AppSettings["SqlServerUserId"]);
        public static string SqlServerDatabase = Convert.ToString(ConfigurationManager.AppSettings["SqlServerDatabase"]);
        public static string SqlServerPassword = Convert.ToString(ConfigurationManager.AppSettings["SqlServerPassword"]);
        public static int SqlServerBulkBatchSize = Convert.ToInt32(ConfigurationManager.AppSettings["SqlServerBulkBatchSize"]);
        public static string SqlServerTableName = Convert.ToString(ConfigurationManager.AppSettings["SqlServerTableName"]);
        public static string HubSpotContactsUrl = Convert.ToString(ConfigurationManager.AppSettings["HubSpotContactsUrl"]);
        public static string HubSpotAccessToken = Convert.ToString(ConfigurationManager.AppSettings["HubSpotAccessToken"]);
    }
}