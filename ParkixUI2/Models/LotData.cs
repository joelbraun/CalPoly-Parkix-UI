using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Models
{
    /// <summary>
    /// The basic class used to track individual lot data.
    /// </summary>
    public class LotData
    {
        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }

        [JsonProperty("value")]
        public double value { get; set; }
    }
}
