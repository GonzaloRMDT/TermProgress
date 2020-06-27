using System;
using Moq;
using TermProgress.Library.Helpers;

namespace TermProgress.Tests.Mocks
{
    /// <summary>
    /// Represents a system clock mock.
    /// </summary>
    public class SystemClockMock : Mock<ISystemClock>
    {
        public SystemClockMock MockNow(DateTime dateTime)
        {
            Setup(x => x.Now).Returns(dateTime);
            return this;
        }
    }
}