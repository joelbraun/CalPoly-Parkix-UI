using Newtonsoft.Json;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkixUI2.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private static IConfigurationService instance;

        private static readonly HttpClient configureClient = new HttpClient();

        public static IConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }
                return instance;
            }
        }

        public string Token { get; set; }

        public Dictionary<string,string> GetAssociations()
        {
            var dataRequest = new HttpRequestMessage(HttpMethod.Get, "https://cp-parkix-configure.run.aws-usw02-pr.ice.predix.io/api/associations");
            dataRequest.Headers.Add("authorization", Token);

            var data = configureClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        }


        public List<string> GetSensors()
        {
            var dataRequest = new HttpRequestMessage(HttpMethod.Get, "https://cp-parkix-configure.run.aws-usw02-pr.ice.predix.io/api/sensors/");
            dataRequest.Headers.Add("authorization", Token);

            var data = configureClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<String>>(data);
        }

        public string GetImage(string sensorId)
        {
            var dataRequest = new HttpRequestMessage(HttpMethod.Get, $"https://cp-parkix-configure.run.aws-usw02-pr.ice.predix.io/api/sensors/{sensorId}/image");
            dataRequest.Headers.Add("authorization", Token);

            var data = configureClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            return data;
        }

        public bool SendConfiguration(string sensorId, string configuration)
        {
            var dataRequest = new HttpRequestMessage(HttpMethod.Post, "");
            dataRequest.Headers.Add("authorization", Token);

            return configureClient.SendAsync(dataRequest).Result.IsSuccessStatusCode;
        }
    }
}
