using System;
using Microsoft.Extensions.Options;
using Moq;
using TermProgress.Library.Configurations;
using TermProgress.Library.Terms;
using TermProgress.Tests.Mocks;
using Xunit;

namespace TermProgress.Tests.Tests.Terms
{
    /// <summary>
    /// Represents the term progress bar tests.
    /// </summary>
    public class TermProgressBarTests
    {
        [Fact]
        public void Compose_MidnightAfterFirstTermDay_ReturnsProgressBarWithOnlyUncompleteBlocks()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermConfiguration>>();
            termConfigurationMock.Setup(x => x.Value).Returns(CreateTermConfiguration());

            var termMock = new TermMock()
                .MockTotalDays(1461)
                .MockElapsedDays(1);

            var termProgressBarBlockFactoryMock = new TermProgressBarBlockFactoryMock()
                .MockCreateProgressBarBlock(CreateCompletedTermProgressBarBlock(), CreateUncompletedTermProgressBarBlock());

            var termProgressBar = new TermProgressBar(termConfigurationMock.Object, termMock.Object, termProgressBarBlockFactoryMock.Object);

            //// Act
            var result = termProgressBar.Compose();

            //// Assert
            Assert.IsType<string>(result);
            Assert.Equal("░░░░░░░░░░░░░░░", result);
        }

        [Fact]
        public void Compose_MidnightAfterLastTermDay_ReturnsProgressBarWithOnlyCompleteBlocks()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermConfiguration>>();
            termConfigurationMock.Setup(x => x.Value).Returns(CreateTermConfiguration());

            var termMock = new TermMock()
                .MockElapsedDays(1461)
                .MockTotalDays(1461);

            var termProgressBarBlockFactoryMock = new TermProgressBarBlockFactoryMock()
                .MockCreateProgressBarBlock(CreateCompletedTermProgressBarBlock(), CreateUncompletedTermProgressBarBlock());

            var termProgressBar = new TermProgressBar(termConfigurationMock.Object, termMock.Object, termProgressBarBlockFactoryMock.Object);

            // Act
            var result = termProgressBar.Compose();

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓", result);
        }

        private TermConfiguration CreateTermConfiguration()
        {
            return new TermConfiguration
            {
                DurationInYears = 4,
                ProgressBarCompletedBlockSymbol = '▓',
                ProgressBarUncompletedBlockSymbol = '░',
                ProgressBarBlocksTotal = 15,
                StartingDateTime = new DateTime(2019, 12, 10, 10, 0, 0)
            };
        }

        private TermProgressBarBlock CreateCompletedTermProgressBarBlock()
        {
            return new TermProgressBarBlock
            {
                Type = TermProgressBarBlockType.Completed,
                Symbol = '▓'
            };
        }

        private TermProgressBarBlock CreateUncompletedTermProgressBarBlock()
        {
            return new TermProgressBarBlock
            {
                Type = TermProgressBarBlockType.Uncompleted,
                Symbol = '░'
            };
        }
    }
}
