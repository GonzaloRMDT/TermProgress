using System;
using TermProgress.Domain.Terms;
using Xunit;

namespace TermProgress.Tests.Domain.Terms
{
    /// <summary>
    /// Represents the <see cref="TermMessage"/> tests.
    /// </summary>
    public class TermMessageTests
    {
        [Fact]
        public static void Bar_at_midnight_after_inauguration_is_empty()
        {
            // Act
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            TermMessage termMessage = new(term);

            // Arrange
            var result = termMessage.GetProgressBar();

            // Assert
            Assert.Equal("░░░░░░░░░░░░░░░", result);
        }

        [Fact]
        public static void Bar_at_midnight_before_inauguration_is_full()
        {
            // Act
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            TermMessage termMessage = new(term);

            // Arrange
            var result = termMessage.GetProgressBar();

            // Assert
            Assert.Equal("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓", result);
        }

        private static DateTime GetStartDate() => new DateTime(2019, 12, 10);

        private static DateTime GetEndDate() => new DateTime(2023, 12, 9);
    }
}
