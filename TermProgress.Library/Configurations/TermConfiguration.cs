using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents a term configuration.
    /// </summary>
    /// <inheritdoc />
    public class TermConfiguration : ITermConfiguration
    {
        public DateTime StartingDateTime { get; set; }

        public int DurationInYears { get; set; }

        public char ProgressBarCompletedBlockSymbol { get; set; }

        public char ProgressBarUncompletedBlockSymbol { get; set; }

        public int ProgressBarBlocksTotal { get; set; }
    }
}
