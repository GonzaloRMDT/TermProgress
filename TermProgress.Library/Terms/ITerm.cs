using System;

namespace TermProgress.Domain.Terms
{
    /// <summary>
    /// Defines the common structure for terms.
    /// </summary>
    public interface ITerm
    {
        /// <summary>
        /// Gets or initializes the current date.
        /// </summary>
        DateTime CurrentDate { get; init; }

        /// <summary>
        /// Gets the number of days elapsed.
        /// </summary>
        int GetDaysElapsed();

        /// <summary>
        /// Gets the number of days remaining.
        /// </summary>
        int GetDaysRemaining();

        /// <summary>
        /// Gets the total number of days.
        /// </summary>
        int GetDaysTotal();

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when end date is not set.</exception>
        DateTime GetEndDate();

        /// <summary>
        /// Gets the progress ratio.
        /// </summary>
        double GetProgressRatio();

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when start date is not set.</exception>
        DateTime GetStartDate();

        /// <summary>
        /// Sets the end date.
        /// </summary>
        /// <param name="value">The end date.</param>
        /// <exception cref="ArgumentException">Thrown when value is greater than start date.</exception>
        void SetEndDate(DateTime value);

        /// <summary>
        /// Sets the start date.
        /// </summary>
        /// <param name="value">The start date.</param>
        /// <exception cref="ArgumentException">Thrown when value is greater than end date.</exception>
        void SetStartDate(DateTime value);
    }
}
