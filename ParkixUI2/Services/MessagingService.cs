using ParkixUI2.Models;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkixUI2.Services
{
    public class MessagingService : IMessagingService
    {
        private static IMessagingService instance;

        private static IEventService eventService = EventService.Instance;
        private static readonly HttpClient configureClient = new HttpClient();

        public static IMessagingService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessagingService();
                }
                return instance;
            }
        }

        public string Token { get; set; }

        /// <summary>
        /// Due to time constraints and problems fetching events dynamically, we were unable to predictively filter events.
        /// Thus, we message the user for all events.
        /// </summary>
        /// <returns></returns>
        public List<Message> GetMessages()
        {
            var messages = new List<Message>();
            foreach (Event e in eventService.GetEvents())
            {
                var m = new Message();
                m.subject = "Higher than average parking needs anticipated.";
                m.message = $"Parkix is anticipating higher than average parking needs due to the event \"{e.Title}\" on {e.StartTime.ToString("MM-dd-yyyy")}. <p><a href=\"/Analytics\">View Predicted Trend Data</a></p>";
                m.timestamp = e.StartTime;

                messages.Add(m);
            }

            return messages;
        }
    }
}
