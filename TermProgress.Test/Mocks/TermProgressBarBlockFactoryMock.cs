using System;
using Moq;
using TermProgress.Library.Terms;

namespace TermProgress.Tests.Mocks
{
    /// <summary>
    /// Represents a term progress bar block factory mock.
    /// </summary>
    public class TermProgressBarBlockFactoryMock : Mock<ITermProgressBarBlockFactory>
    {
        public TermProgressBarBlockFactoryMock MockCreateProgressBarBlock(TermProgressBarBlock completeProgressBarBlock, TermProgressBarBlock uncompleteProgressBarBlock)
        {
            Setup(x => x.CreateProgressBarBlock(It.IsAny<double>(), It.IsAny<double>()))
                .Returns((double progressBarBlockDays, double elapsedDays) => progressBarBlockDays <= elapsedDays ? completeProgressBarBlock : uncompleteProgressBarBlock);
            return this;
        }
    }
}