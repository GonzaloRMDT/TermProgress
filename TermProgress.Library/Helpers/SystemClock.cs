using System;

namespace TermProgress.Library.Helpers
{
    /// <summary>
    /// Represents the system clock.
    /// </summary>
    public class SystemClock : ISystemClock
    {
        /// <summary>
        /// System date and time.
        /// </summary>
        public DateTime Now
        {
            get => DateTime.Now;
        }
    }
}
