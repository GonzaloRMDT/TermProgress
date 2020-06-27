using System;
using Moq;
using TermProgress.Library.Terms;

namespace TermProgress.Tests.Mocks
{
    /// <summary>
    /// Represents a term mock.
    /// </summary>
    public class TermMock : Mock<ITerm>
    {
        public TermMock MockStartingDate(DateTime startingDate)
        {
            Setup(x => x.StartingDate).Returns(startingDate);
            return this;
        }

        public TermMock MockEndingDate(DateTime endingDate)
        {
            Setup(x => x.EndingDate).Returns(endingDate);
            return this;
        }

        public TermMock MockTotalDays(int totalDays)
        {
            Setup(x => x.TotalDays).Returns(totalDays);
            return this;
        }

        public TermMock MockElapsedDays(int elapsedDays)
        {
            Setup(x => x.ElapsedDays).Returns(elapsedDays);
            return this;
        }

        public TermMock MockRemainingDays(int remainingDays)
        {
            Setup(x => x.RemainingDays).Returns(remainingDays);
            return this;
        }

        public TermMock MockProgress(double progress)
        {
            Setup(x => x.Progress).Returns(progress);
            return this;
        }
    }
}