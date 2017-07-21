using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IPredictionService
    {
        /// <summary>
        /// Returns predefined class schedule data for display.
        /// </summary>
        /// <returns></returns>
        List<double> GetScheduleData();

        /// <summary>
        /// Returns predictions based on Gradient functionality.
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        List<double> GetPrediction(string lot);

        string Token { get; set; }
    }
}
