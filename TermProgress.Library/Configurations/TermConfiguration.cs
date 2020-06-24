using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents a term configuration.
    /// </summary>
    public class TermConfiguration : ITermConfiguration
    {
        /// <summary>
        /// Term starting date and time.
        /// </summary>
        public DateTime StartingDateTime { get; set; }

        /// <summary>
        /// Term duration measured in years.
        /// </summary>
        public int DurationInYears { get; set; }

        /// <summary>
        /// Term progress bar completed symbol.
        /// </summary>
        public char ProgressBarCompletedSymbol { get; set; }

        /// <summary>
        /// Term progress bar uncompleted symbol.
        /// </summary>
        public char ProgressBarUncompletedSymbol { get; set; }

        /// <summary>
        /// Term progress bar symbol total.
        /// </summary>
        public int ProgressBarSymbolsTotal { get; set; }
    }
}
