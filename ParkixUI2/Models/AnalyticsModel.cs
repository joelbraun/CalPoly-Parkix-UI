using System.Collections.Generic;

namespace ParkixUI2.Models
{
    public class AnalyticsModel
    {

        /// <summary>
        /// Actual data, stored as a string formatted as a JS array.
        /// </summary>
        public string ActualData { get; set; }

        /// <summary>
        /// Predicted data, stored as a string formatted as a JS array.
        /// </summary>
        public string PredictedData { get; set; }

        /// <summary>
        /// Schedule data, stored as a string formatted as a JS array.
        /// </summary>
        public string ScheduleData { get; set; }

        /// <summary>
        /// Lists event data in use by the application.
        /// </summary>
        public List<Event> Events { get; set; }

        /// <summary>
        /// Lists system notifications.
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        /// Lists the weather.
        /// </summary>
        public List<int> Weather { get; set; }

        public AnalyticsModel()
        {
            
        }
    }
}