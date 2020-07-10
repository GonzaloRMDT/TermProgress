using System;

namespace TermProgress.Library.Providers
{
    /// <summary>
    /// Represents a DateTime provider.
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
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
