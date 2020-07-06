using System;
using Microsoft.Extensions.Options;
using Moq;
using TermProgress.Library.Configurations;
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
            var termConfigurationMock = new Mock<IOptions<TermConfiguration>>();
            termConfigurationMock.Setup(x => x.Value).Returns(CreateTermConfiguration());

            var termProgressBarBlockFactory = new TermProgressBarBlockFactory(termConfigurationMock.Object);

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
            var termConfigurationMock = new Mock<IOptions<TermConfiguration>>();
            termConfigurationMock.Setup(x => x.Value).Returns(CreateTermConfiguration());

            var termProgressBarBlockFactory = new TermProgressBarBlockFactory(termConfigurationMock.Object);

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
            var termConfigurationMock = new Mock<IOptions<TermConfiguration>>();
            termConfigurationMock.Setup(x => x.Value).Returns(CreateTermConfiguration());

            var termProgressBarBlockFactory = new TermProgressBarBlockFactory(termConfigurationMock.Object);

            // Act
            var result = termProgressBarBlockFactory.CreateProgressBarBlock(0.9, 0.75);

            // Asert
            Assert.IsType<TermProgressBarBlock>(result);
            Assert.Equal(TermProgressBarBlockType.Uncompleted, result.Type);
            Assert.Equal('░', result.Symbol);
        }

        private TermConfiguration CreateTermConfiguration()
        {
            return new TermConfiguration
            {
                ProgressBarCompletedBlockSymbol = '▓',
                ProgressBarUncompletedBlockSymbol = '░'
            };
        }
    }
}