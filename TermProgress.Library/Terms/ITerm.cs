using System;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for terms.
    /// </summary>
    public interface ITerm
    {
        /// <summary>
        /// Gets the term starting <see cref="DateTime"/>.
        /// </summary>
        DateTime StartingDate { get; }

        /// <summary>
        /// Gets the term ending <see cref="DateTime"/>.
        /// </summary>
        DateTime EndingDate { get; }

        /// <summary>
        /// Gets the term total days.
        /// </summary>
        int TotalDays { get; }

        /// <summary>
        /// Gets the term elapsed days.
        /// </summary>
        int ElapsedDays { get; }

        /// <summary>
        /// Gets the term remaining days.
        /// </summary>
        int RemainingDays { get; }

        /// <summary>
        /// Gets the term progress.
        /// </summary>
        double Progress { get; }
    }
}