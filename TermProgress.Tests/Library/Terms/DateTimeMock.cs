using System;
using TermProgress.Library.Terms;

namespace TermProgress.Tests.Library.Terms
{
    /// <summary>
    /// Represents a <see cref="DateTime"/> mock.
    /// </summary>
    public class DateTimeMock : IDateTimeWrapper
    {
        private readonly DateTime now;

        public DateTime Now
        {
            get
            {
                return now;
            }
        }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="now">A given <see cref="DateTime"/>.</param>
        public DateTimeMock(DateTime now)
        {
            this.now = now;
        }
    }
}
