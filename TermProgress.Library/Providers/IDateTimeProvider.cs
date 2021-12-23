using System;

namespace TermProgress.Library.Providers
{
    /// <summary>
    /// <c>IDateTimeProvider</c> interface.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets the current system <see cref="DateTime"/>.
        /// </summary>
        /// A <see cref="DateTime"/> value.
        DateTime Now { get; }
    }
}
