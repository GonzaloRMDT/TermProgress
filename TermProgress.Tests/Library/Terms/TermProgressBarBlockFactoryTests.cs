using Microsoft.Extensions.Options;
using Moq;
using System;
using TermProgress.Library.Options;
using TermProgress.Library.Terms;
using Xunit;

namespace TermProgress.Tests.Library.Terms
{
    /// <summary>
    /// Represents a term progress bar block factor class tests.
    /// </summary>
    public class TermProgressBarBlockFactoryTests
    {
        [Fact]
        public void CreateProgressBarBlock_ProgressBarBlockDaysAreLessThanElapsedDays_ReturnsCompletedProgressBarBlock()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var termProgressBarBlockFactory = new TermProgressBarBlockFactory();

            // Act
            var result = termProgressBarBlockFactory.CreateProgressBarBlock(0.5, 0.75);

            // Asert
            Assert.IsType<TermProgressBarBlock>(result);
            Assert.Equal(TermProgressBarBlockType.Completed, result.Type);
            Assert.Equal('▓', result.Symbol);
        }

        [Fact]
        public void CreateProgressBarBlock_ProgressBarBlockDaysAreSameAsElapsedDays_ReturnsCompletedProgressBarBlock()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var termProgressBarBlockFactory = new TermProgressBarBlockFactory();

            // Act
            var result = termProgressBarBlockFactory.CreateProgressBarBlock(0.75, 0.75);

            // Asert
            Assert.IsType<TermProgressBarBlock>(result);
            Assert.Equal(TermProgressBarBlockType.Completed, result.Type);
            Assert.Equal('▓', result.Symbol);
        }

        [Fact]
        public void CreateProgressBarBlock_ProgressBarBlockDaysAreGreaterThanThanElapsedDays_ReturnsUncompletedProgressBarBlock()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var termProgressBarBlockFactory = new TermProgressBarBlockFactory();

            // Act
            var result = termProgressBarBlockFactory.CreateProgressBarBlock(0.9, 0.75);

            // Asert
            Assert.IsType<TermProgressBarBlock>(result);
            Assert.Equal(TermProgressBarBlockType.Uncompleted, result.Type);
            Assert.Equal('░', result.Symbol);
        }

        private TermOptions GetTermOptions()
        {
            return new TermOptions()
            {
                StartingDateTime = new DateTime(2019, 12, 10, 10, 0, 0),
                EndingDateTime = new DateTime(2023, 12, 10, 0, 0, 0)
            };
        }
    }
}