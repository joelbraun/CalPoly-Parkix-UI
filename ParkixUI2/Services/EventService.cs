using ParkixUI2.Models;
using ParkixUI2.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services
{
    public class EventService : IEventService
    {
        private static IEventService instance;

        public static IEventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }

        /// <summary>
        /// In a perfect world, Cal Poly would provide a public API to their campus calendar.
        /// Unfortunately, that's strongly discouraged so we avoid it and use a few static data points.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event
                {
                    Title = "Admissions Info Session",
                    Description = "An admissions info session.",
                    StartTime = DateTime.Now
                },
                new Event
                {
                    Title = "Collegians Big-Band Alumni Concert",
                    Description = "A big-band alumni concert.",
                    StartTime = DateTime.Now
                },
                new Event
                {
                    Title = "California Climate Action Planning Conference",
                    Description = "A climate action planning conference.",
                    StartTime = DateTime.Now
                },
                new Event
                {
                    Title = "Creative Economy Forum",
                    Description = "A forum on creative economies.",
                    StartTime = DateTime.Now
                }
            };
        }


    }
}
