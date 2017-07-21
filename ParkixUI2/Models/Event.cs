using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Models
{
    /// <summary>
    /// The basic class used to handle calendar events.
    /// </summary>
    public class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
