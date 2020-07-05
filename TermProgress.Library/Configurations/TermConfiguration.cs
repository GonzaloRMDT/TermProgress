using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents a term configuration.
    /// </summary>
    public class TermConfiguration
    {
        /// <summary>
        /// Gets or sets the term starting date and time.
        /// </summary>
        public DateTime StartingDateTime { get; set; }

        /// <summary>
        /// Gets or sets the term duration measured in years.
        /// </summary>
        public int DurationInYears { get; set; }

        /// <summary>
        /// Gets or sets the term progress bar completed block symbol.
        /// </summary>
        public char ProgressBarCompletedBlockSymbol { get; set; }

        /// <summary>
        /// Gets or sets the term progress bar uncompleted block symbol.
        /// </summary>
        public char ProgressBarUncompletedBlockSymbol { get; set; }

        /// <summary>
        /// Gets or sets the term progress bar blocks total.
        /// </summary>
        public int ProgressBarBlocksTotal { get; set; }
    }
}
