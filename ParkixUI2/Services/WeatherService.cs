using Newtonsoft.Json.Linq;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkixUI2.Services
{
    public class WeatherService : IWeatherService
    {

        private static IWeatherService instance;

        public static IWeatherService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherService();
                }
                return instance;
            }
        }

        public static readonly HttpClient weatherClient = new HttpClient();


        /// <summary>
        /// Returns temperatures for the next five days.
        /// We had intended to use PREDIX weather for this, but it got shut down.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<int> GetWeather(string location)
        {
            var dataRequest = new HttpRequestMessage(HttpMethod.Get, $"http://api.wunderground.com/api/845fc68efe431729/forecast/q/CA/{location}.json");

            var result = weatherClient.SendAsync(dataRequest).Result.Content.ReadAsStringAsync().Result;

            dynamic weather = JObject.Parse(result);

            var weatherData = new List<int>();

            foreach (dynamic item in weather["forecast"]["simpleforecast"]["forecastday"])
            {
                weatherData.Add(int.Parse(item["high"]["fahrenheit"].Value));
            }

            return weatherData;
        }
    }
}
