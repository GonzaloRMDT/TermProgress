using System;
using TermProgress.Domain.Terms;
using Xunit;

namespace TermProgress.Tests.Domain.Terms
{
    /// <summary>
    /// Represents the <see cref="Term"/> tests.
    /// </summary>
    public class TermTests
    {
        [Fact]
        public static void Elapsed_days_at_midnight_after_inauguration_is_1()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());


            // Act
            var result = term.GetDaysElapsed();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public static void Elapsed_days_at_midnight_before_inauguration_is_equal_to_total_days()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            var result = term.GetDaysElapsed();

            // Assert
            Assert.Equal(1461, result);
        }

        [Fact]
        public static void Progress_at_midnight_after_inauguration_is_0_0006844626967830253()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            var result = term.GetProgressRatio();

            // Assert
            Assert.Equal(0.0006844626967830253, result);
        }

        [Fact]
        public static void Progress_at_midnight_before_inauguration_is_1()
        {
            // Act
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Arrange
            var result = term.GetProgressRatio();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public static void Remaining_days_at_midnight_after_inauguration_is_equal_to_total_days_minus_one()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            var result = term.GetDaysRemaining();

            // Assert
            Assert.Equal(1460, result);
        }

        [Fact]
        public static void Remaining_days_at_midnight_before_inauguration_is_zero()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            var result = term.GetDaysRemaining();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public static void Total_days_is_1461()
        {
            // Arrange
            Term term = new();
            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            var result = term.GetDaysTotal();

            // Assert
            Assert.Equal(1461, result);
        }

        private static DateTime GetStartDate() => new DateTime(2019, 12, 10);

        private static DateTime GetEndDate() => new DateTime(2023, 12, 9);
    }
}
