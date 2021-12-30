using System;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a <see cref="DateTime"/> wrapper class.
    /// </summary>
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
