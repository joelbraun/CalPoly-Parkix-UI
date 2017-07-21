using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IConfigurationService
    {
        string Token { get; set; }

        /// <summary>
        /// Gets sensor associations for each lot.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetAssociations();

        /// <summary>
        /// Gets a list of sensors.
        /// </summary>
        /// <returns></returns>
        List<string> GetSensors();

        /// <summary>
        /// Returns the saved image from the sensor.
        /// </summary>
        /// <param name="sensorId"></param>
        /// <returns></returns>
        string GetImage(string sensorId);

        /// <summary>
        /// Sends configuration updates to the configuration server.
        /// </summary>
        /// <param name="sensorId"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        bool SendConfiguration(string sensorId, string configuration);
    }
}
