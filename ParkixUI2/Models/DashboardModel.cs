using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ParkixUI2.Models
{
    public class DashboardModel
    {
        /// <summary>
        /// A list of parking lots in the instance.
        /// </summary>
        public List<String> Lots { get; set; }

        /// <summary>
        /// Helper for the current date.
        /// </summary>
        public string Date { get
            {
                return System.DateTime.Now.ToString("MM/dd/yyyy");
            }
        }

        /// <summary>
        /// The total number of spots available.
        /// </summary>
        public int SpotsAvailable { get; set; }

        /// <summary>
        /// The total number of spots in use.
        /// </summary>
        public int SpotsInUse { get; set; }

        /// <summary>
        /// A list of all available sensor edges.
        /// </summary>
        public List<String> Sensors { get; set; }

        /// <summary>
        /// Messages for the user.
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Data to be displayed in the primary and secondary graphs.
        /// </summary>
        public string GraphData  { get; set; }

        /// <summary>
        /// The current percentage fill of the lots.
        /// </summary>
        public int CurrentPercentFull { get; set; }

        /// <summary>
        /// Specific reference data for test lot GE1.
        /// TODO: Replace with a dynamic list of all lots.
        /// </summary>
        public string GE1 {get;set;}

        /// <summary>
        /// Specific reference data for test lot H1.
        /// TODO: Replace with a dynamic list of all lots.
        /// </summary>
        public string H1 {get;set;}

        /// <summary>
        /// The total number of spots in use, formatted for a specific chart.
        /// </summary>
        public string TotalInUse {get;set;}

        /// <summary>
        /// A list of all events logged by the system.
        /// </summary>
        public List<Event> Events { get; set; }
    }
}
