using Microsoft.Extensions.Options;
using System;
using TermProgress.Library.Options;
using TermProgress.Library.Terms;
using Xunit;

namespace TermProgress.Tests.Library.Terms
{
    /// <summary>
    /// Represents the <c>Term</c> tests.
    /// </summary>
    public class TermTests
    {
        [Fact]
        public void Elapsed_days_at_midnight_after_inauguration_is_1()
        {
            // Arrange
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2019, 12, 11);

            // Act
            var result = term.ElapsedDays;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Elapsed_days_at_midnight_before_inauguration_is_equal_to_total_days()
        {
            // Arrange
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2023, 12, 10);

            // Act
            var result = term.ElapsedDays;

            // Assert
            Assert.Equal(1461, result);
        }

        [Fact]
        public void Progress_at_midnight_after_inauguration_is_0_0006844626967830253()
        {
            // Arrange
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2019, 12, 11);

            // Act
            var result = term.Progress;

            // Assert
            Assert.Equal(0.0006844626967830253, result);
        }

        [Fact]
        public void Progress_at_midnight_before_inauguration_is_1()
        {
            // Act
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2023, 12, 10);

            // Arrange
            var result = term.Progress;

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Remaining_days_at_midnight_after_inauguration_is_equal_to_total_days_minus_one()
        {
            // Arrange
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2019, 12, 11);

            // Act
            var result = term.RemainingDays;

            // Assert
            Assert.Equal(1460, result);
        }

        [Fact]
        public void Remaining_days_at_midnight_before_inauguration_is_zero()
        {
            // Arrange
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);
            term.CurrentDate = new DateTime(2023, 12, 10);

            // Act
            var result = term.RemainingDays;

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Total_days_is_1461()
        {
            // Arrange
            IOptions<TermOptions> termOptions = GetTermOptions();
            Term term = new Term(termOptions);

            // Act
            var result = term.TotalDays;

            // Assert
            Assert.Equal(1461, result);
        }

        private IOptions<TermOptions> GetTermOptions()
        {
            return Options.Create(new TermOptions()
            {
                StartingDate = new DateTime(2019, 12, 10, 10, 0, 0),
                EndingDate = new DateTime(2023, 12, 10, 0, 0, 0)
            });
        }
    }
}
