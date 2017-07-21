using ParkixUI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkixUI2.Services.Contracts
{
    public interface IMessagingService
    {
        /// <summary>
        /// Returns a list of messages.
        /// </summary>
        /// <returns></returns>
        List<Message> GetMessages();
    }
}
