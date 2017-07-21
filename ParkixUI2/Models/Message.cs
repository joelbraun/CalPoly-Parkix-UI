using System;

namespace ParkixUI2.Models
{
    /// <summary>
    /// A simple class for tracking user messages.
    /// </summary>
    public class Message
    {
        public string subject { get; set; }
        public DateTime timestamp { get; set; }

        public string message { get; set; }
    }
}
