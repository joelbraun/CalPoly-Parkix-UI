using ParkixUI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IEventService
    {
        /// <summary>
        /// Provides a list of calendar events.
        /// </summary>
        /// <returns></returns>
        List<Event> GetEvents();
    }
}
