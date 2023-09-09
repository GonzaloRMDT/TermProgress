using System;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for terms.
    /// </summary>
    /// <summary>
    /// Defines the common structure for terms.
    /// </summary>
    public interface ITerm
    {
        /// <summary>
        /// Gets or sets the current date.
        /// </summary>
        DateTime? CurrentDate { get; set; }

        /// <summary>
        /// Gets the term elapsed days.
        /// </summary>
        int? ElapsedDays { get; }

        /// <summary>
        /// Gets or sets the term ending <see cref="DateTime"/>.
        /// </summary>
        DateTime? EndingDate { get; set; }

        /// <summary>
        /// Gets the term progress.
        /// </summary>
        double? Progress { get; }

        /// <summary>
        /// Gets the term remaining days.
        /// </summary>
        int? RemainingDays { get; }

        /// <summary>
        /// Gets or sets the term starting <see cref="DateTime"/>.
        /// </summary>
        DateTime? StartingDate { get; set; }

        /// <summary>
        /// Gets the term total days.
        /// </summary>
        int? TotalDays { get; }
    }
}
