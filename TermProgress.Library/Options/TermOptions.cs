using System;

namespace TermProgress.Library.Options
{
    /// <summary>
    /// Represents the term options.
    /// </summary>
    public class TermOptions
    {
        /// <summary>
        /// Gets or sets the term starting <see cref="DateTime"/>.
        /// </summary>
        public DateTime StartingDateTime { get; set; }

        /// <summary>
        /// Gets or sets the term ending <see cref="DateTime"/>.
        /// </summary>
        public DateTime EndingDateTime { get; set; }
    }
}
