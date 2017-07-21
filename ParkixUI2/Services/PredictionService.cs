using Newtonsoft.Json;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkixUI2.Services
{
    /// <summary>
    /// This class serves as a data source for predicted data and schedule data - which
    /// is not at this time used in the prediction. 
    /// </summary>
    public class PredictionService : IPredictionService
    {
        private static IPredictionService instance;

        private static readonly HttpClient predictionClient = new HttpClient();

        public string Token {get; set;}

        public static IPredictionService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PredictionService();
                }
                return instance;
            }
        }

        /// <summary>
        /// Provides us with predicted data for use in the analytics engine.
        /// </summary>
        public List<double> GetPrediction(string lot)
        {
            var dataRequest = new HttpRequestMessage(HttpMethod.Get, $"https://cp-parkix-report.run.aws-usw02-pr.ice.predix.io/api/lot/{lot}/predict/tomorrow");
            dataRequest.Headers.Add("authorization", Token);
            var result = predictionClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            var data = Downsample(JsonConvert.DeserializeObject<List<double>>(result));

            //Because of time constraints, all predictions shown in the user interface are based upon
            //the 20-slot sample lot data from the Current API. 
            //We scale here to 20 to match the lot size, and then multiply by 100 to get a percentage value.
            return data.Select(x => (x / 20f) * 100).ToList();
        }

        /// <summary>
        /// Statically returns schedule data, as extracted from a CSV format.
        /// We use static data, and then scale to percentage amounts based on a spot count of 6500.
        /// TODO: Add data dynamically at some point.
        /// </summary>
        /// <returns></returns>
        public List<double> GetScheduleData()
        {
            return new List<double>
            {
                676, 958, 3477, 5181, 5859, 6009, 5998, 775, 5742, 5903, 5615, 5220, 4794, 4770, 4499, 4412, 4326, 4184, 2085, 1814, 1652
            }.Select(x => (x / 6500f) * 100).ToList();
        }
        
        /// Helper method for downsampling data points from the reporting instance.
        /// Magic number 14 comes from the fact that a prediction will return roughly
        /// 280 data points and we want it sampled down to around twenty.
        private List<double> Downsample(List<double> data)
        {
            var results = new List<double>();

            for (int i = 0; i < data.Count; i++)
            {
                if (i % 14 == 0)
                {
                    results.Add(data[i]);
                }
                    
            }

            return results;
        }
    }
}
