using Moq;
using System;
using TermProgress.Library.Providers;

namespace TermProgress.Tests.Library.Helpers
{
    /// <summary>
    /// Represents a DateTime provider.
    /// </summary>
    public class DateTimeProviderMock : Mock<IDateTimeProvider>
    {
        public DateTimeProviderMock MockNow(DateTime dateTime)
        {
            Setup(x => x.Now).Returns(dateTime);
            return this;
        }
    }
}