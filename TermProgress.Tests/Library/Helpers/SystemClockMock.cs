using System;
using Moq;
using TermProgress.Library.Providers;

namespace TermProgress.Tests.Library.Helpers
{
    /// <summary>
    /// Represents a system clock mock.
    /// </summary>
    public class SystemClockMock : Mock<IDateTimeProvider>
    {
        public SystemClockMock MockNow(DateTime dateTime)
        {
            Setup(x => x.Now).Returns(dateTime);
            return this;
        }
    }
}