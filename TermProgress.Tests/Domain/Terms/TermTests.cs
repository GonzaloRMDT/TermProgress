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
        public static void Days_elapsed_at_midnight_after_inauguration_equals_1()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());


            // Act
            int result = term.GetDaysElapsed();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public static void Days_elapsed_at_midnight_before_inauguration_equals_days_total()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            int result = term.GetDaysElapsed();

            // Assert
            Assert.Equal(1461, result);
        }

        [Fact]
        public static void Days_remaining_at_midnight_after_inauguration_equals_days_total_minus_1()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            int result = term.GetDaysRemaining();

            // Assert
            Assert.Equal(1460, result);
        }

        [Fact]
        public static void Days_remaining_at_midnight_before_inauguration_equals_0()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            int result = term.GetDaysRemaining();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public static void Days_total_equals_1461()
        {
            // Arrange
            Term term = new();
            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            int result = term.GetDaysTotal();

            // Assert
            Assert.Equal(1461, result);
        }

        [Fact]
        public static void Progress_ratio_at_midnight_after_inauguration_equals_0_0006844626967830253()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2019, 12, 11)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            double result = term.GetProgressRatio();

            // Assert
            Assert.Equal(0.0006844626967830253, result);
        }

        [Fact]
        public static void Progress_ratio_at_midnight_before_inauguration_equals_1()
        {
            // Arrange
            Term term = new()
            {
                CurrentDate = new DateTime(2023, 12, 10)
            };

            term.SetStartDate(GetStartDate());
            term.SetEndDate(GetEndDate());

            // Act
            double result = term.GetProgressRatio();

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public static void Setting_end_date_throws_argument_exception_when_value_is_less_than_start_date()
        {
            // Arrange
            Term term = new();

            term.SetStartDate(GetStartDate());

            ArgumentException? thrownException = null;

            // Act
            try
            {
                term.SetEndDate(GetStartDate().AddDays(-1));
            }
            catch (ArgumentException ex)
            {
                thrownException = ex;
            }

            // Assert
            Assert.NotNull(thrownException);
            Assert.IsType<ArgumentException>(thrownException);
            Assert.Equal("Value cannot be less than start date.", thrownException?.Message);
        }

        [Fact]
        public static void Setting_start_date_throws_argument_exception_when_value_is_greater_than_end_date()
        {
            // Arrange
            Term term = new();

            term.SetEndDate(GetEndDate());

            ArgumentException? thrownException = null;

            // Act
            try
            {
                term.SetStartDate(GetEndDate().AddDays(11));
            }
            catch (ArgumentException ex)
            {
                thrownException = ex;
            }

            // Assert
            Assert.NotNull(thrownException);
            Assert.IsType<ArgumentException>(thrownException);
            Assert.Equal("Value cannot be greater than end date.", thrownException?.Message);
        }

        private static DateTime GetStartDate() => new DateTime(2019, 12, 10);

        private static DateTime GetEndDate() => new DateTime(2023, 12, 9);
    }
}
