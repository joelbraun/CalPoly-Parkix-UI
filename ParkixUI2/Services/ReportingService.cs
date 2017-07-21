using Newtonsoft.Json;
using ParkixUI2.Models;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkixUI2.Services
{
    public class ReportingService : IReportingService
    {
        private static IReportingService instance;

        private static readonly HttpClient reportClient = new HttpClient();

        public static IReportingService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReportingService();
                }
                return instance;
            }
        }

        public string Token { get; set; }

        public double GetLatestLotData(string lot)
        {

            var dataRequest = new HttpRequestMessage(HttpMethod.Get, $"https://cp-parkix-report.run.aws-usw02-pr.ice.predix.io/api/lot/{lot}/latest");
            dataRequest.Headers.Add("authorization", Token);
            var result = reportClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            return double.Parse(result);
        }

        public List<LotData> GetHistoricalLotData(string lot, DateTime start, DateTime end)
        {
            var startDate = start.ToString("yyyy-MM-dd");
            var endDate = end.ToString("yyyy-MM-dd");

            var dataRequest = new HttpRequestMessage(HttpMethod.Get, $"https://cp-parkix-report.run.aws-usw02-pr.ice.predix.io/api/lot/{lot}/historical?start={startDate}&end={endDate}");
            dataRequest.Headers.Add("authorization", Token);

            var result = reportClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<LotData>>(result);
        } 

    }
}
