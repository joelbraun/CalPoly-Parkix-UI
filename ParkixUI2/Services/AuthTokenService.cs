using Newtonsoft.Json.Linq;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ParkixUI2.Services
{
    public class AuthTokenService : IAuthTokenService
    {
        private static IAuthTokenService instance;

        //Gather all data from the appconfig.
        private static readonly string configureUName = "configure_client";
        private static readonly string configureSecret = "WMEv8luHI662207td9YFw4SIAuUy9nsM79VKLh4HQOOA7hzFvHTf0t3FcZCkmdtb9aWswGpifS0BPbUqJKvXMtcS2oBG0B9GoIcxf22Jh4J7kmg46fKrGYZVsATfCBdx";
        private static readonly string reportUName = "report_client";
        private static readonly string reportSecret = "F8dQA3fOqzdXdZsknaobYKiWIG7xFi71JRmhQMGahIhH09ObiF9nzmTmO0hd71j9NHNJzj1G73KvAO5t9It2sibnB17vMPMlf7fGFlXvIA7PjZDpA1WlOyBUR21RSj1t";
        private static readonly string uaaUrl = "https://a7cc7c64-503e-43df-ab3a-18c97ef60505.predix-uaa.run.aws-usw02-pr.ice.predix.io/oauth/token";

        //static client for data read, use this to avoid socket issues.
        private static readonly HttpClient tokenClient = new HttpClient();

        public string ConfigureAuthToken { get; private set; }

        public string ReportAuthToken { get; private set; }

        public static IAuthTokenService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthTokenService();
                    instance.GenerateTokens();
                }
                return instance;
            }
        }

        /// <summary>
        /// Generates new OAuth tokens for use with Parkix services.
        /// </summary>
        public void GenerateTokens()
        {
            ConfigureAuthToken = GetOAuthToken(configureUName, configureSecret);
            ReportAuthToken = GetOAuthToken(reportUName, reportSecret);
        }

        private string GetOAuthToken(string userName, string secret)
        {

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", userName),
                new KeyValuePair<string, string>("grant_type","client_credentials")
            });

            tokenClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{userName}:{secret}")));
            var response = tokenClient.PostAsync(uaaUrl, content).Result.Content.ReadAsStringAsync().Result;

            dynamic tokenData = JObject.Parse(response);

            return tokenData["access_token"].Value;
        }

    }
}
