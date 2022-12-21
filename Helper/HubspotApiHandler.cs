using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HubspotContactsToSqlServer.Helper
{
    public class HubSpotApiHandler
    {
        /// <summary>
        /// Reads the contacts raw data from the hubspot contacts api
        /// </summary>
        /// <returns>contacts</returns>
        public static async Task<string> GetContactsFromHubSpot()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Constants.HubSpotContactsUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.HubSpotAccessToken);
            var response = client.GetAsync(Constants.HubSpotContactsUrl).Result;
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}