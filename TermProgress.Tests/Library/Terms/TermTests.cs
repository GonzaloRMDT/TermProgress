using Microsoft.Extensions.Options;
using Moq;
using System;
using TermProgress.Library.Options;
using TermProgress.Library.Terms;
using TermProgress.Tests.Library.Helpers;
using Xunit;

namespace TermProgress.Tests.Library.Terms
{
    /// <summary>
    /// Term tests.
    /// </summary>
    public class TermTests
    {
        [Fact]
        public void StartingDate_CalculatedValue_ReturnsTermStartingDate()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock();

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.StartingDate;

            // Assert
            Assert.IsType<DateTime>(result);
            Assert.Equal(new DateTime(2019, 12, 10), result);
        }

        [Fact]
        public void EndingDate_CalculatedValue_ReturnsTermEndingDate()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock();

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.EndingDate;

            // Assert
            Assert.IsType<DateTime>(result);
            Assert.Equal(new DateTime(2023, 12, 10), result);
        }

        [Fact]
        public void ElapsedDays_MidnightAfterFirstTermDay_ReturnsOneElapsedDay()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock()
                .MockNow(new DateTime(2019, 12, 11));

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.ElapsedDays;

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(1, result);
        }

        [Fact]
        public void ElapsedDays_MidnightAfterLastTermDay_ReturnsSameElapsedDaysAsPeriodTotalDays()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock()
                .MockNow(new DateTime(2023, 12, 10));

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.ElapsedDays;

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(1461, result);
        }

        [Fact]
        public void RemainingDays_MidnightAfterFirstTermDay_ReturnsTotalDaysMinusOne()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock()
                .MockNow(new DateTime(2019, 12, 11));

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.RemainingDays;

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(1460, result);
        }

        [Fact]
        public void RemainingDays_MidnightAfterLastTermDay_ReturnsZeroRemainingDays()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock()
                .MockNow(new DateTime(2023, 12, 10));

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.RemainingDays;

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TotalDays_CalculatedValue_ReturnsTermTotalDays()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock();

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.TotalDays;

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(1461, result);
        }

        [Fact]
        public void Progress_MidnightAfterFirstTermDay_ReturnsOneDayProgress()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock()
                .MockNow(new DateTime(2019, 12, 11));

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.Progress;

            // Assert
            Assert.IsType<double>(result);
            Assert.Equal(0.0006844626967830253, result);
        }

        [Fact]
        public void Progress_MidnightAfterLastTermDay_ReturnsCompletedProgress()
        {
            // Arrange
            var termConfigurationMock = new Mock<IOptions<TermOptions>>();
            termConfigurationMock.Setup(x => x.Value).Returns(GetTermOptions());

            var dateTimeProvider = new DateTimeProviderMock()
                .MockNow(new DateTime(2023, 12, 10));

            var term = new Term(termConfigurationMock.Object);

            // Act
            var result = term.Progress;

            // Assert
            Assert.IsType<double>(result);
            Assert.Equal(1, result);
        }

        private TermOptions GetTermOptions()
        {
            return new TermOptions
            {
                StartingDateTime = new DateTime(2019, 12, 10, 10, 0, 0),
                EndingDateTime = new DateTime(2023, 12, 10, 0, 0, 0)
            };
        }
    }
}
