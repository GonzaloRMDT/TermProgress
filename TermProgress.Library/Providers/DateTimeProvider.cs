using System;

namespace TermProgress.Library.Providers
{
    /// <summary>
    /// Represents a date and time provider.
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets the system current <see cref="DateTime"/>.
        /// </summary>
        public DateTime Now
        {
            get => DateTime.Now;
        }
    }
}
