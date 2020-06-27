using System;
using Moq;
using TermProgress.Library.Terms;

namespace TermProgress.Tests.Mocks
{
    /// <summary>
    /// Represents a term progress bar mock.
    /// </summary>
    public class TermProgressBarMock : Mock<ITermProgressBar>
    {
        public TermProgressBarMock MockCompose(string progressBar)
        {
            Setup(x => x.Compose()).Returns(progressBar);
            return this;
        }
    }
}
