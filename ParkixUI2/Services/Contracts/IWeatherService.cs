using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the weather (using WUnderground) for a specific location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        List<int> GetWeather(string location);
    }
}
 