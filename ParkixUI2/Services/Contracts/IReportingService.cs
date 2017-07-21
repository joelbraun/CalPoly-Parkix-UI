using ParkixUI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IReportingService
    {
        /// <summary>
        /// Gets historical data between a certain range for a lot.
        /// </summary>
        /// <param name="lot">The parking lot.</param>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <returns></returns>
        List<LotData> GetHistoricalLotData(string lot, DateTime start, DateTime end);
        
        /// <summary>
        /// Gets latest lot data.
        /// </summary>
        /// <param name="lot">The parking lot.</param>
        /// <returns></returns>
        double GetLatestLotData(string lot);

        /// <summary>
        /// The access token to use for gathering lot data.
        /// </summary>
        string Token { get; set; }

    }
}
