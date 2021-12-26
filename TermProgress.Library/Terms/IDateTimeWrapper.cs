using System;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for <see cref="DateTime"/> wrappers.
    /// </summary>
    public interface IDateTimeWrapper
    {
        /// <summary>
        /// Gets the current <see cref="DateTime"/>.
        /// </summary>
        DateTime Now { get; }
    }
}