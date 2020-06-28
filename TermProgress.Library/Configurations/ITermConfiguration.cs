using System;

namespace TermProgress.Library.Configurations
{
    public interface ITermConfiguration
    {
        /// <summary>
        /// Term starting date and time.
        /// </summary>
        DateTime StartingDateTime { get; set; }

        /// <summary>
        /// Term duration measured in years.
        /// </summary>
        int DurationInYears { get; set; }

        /// <summary>
        /// Term progress bar completed block symbol.
        /// </summary>
        char ProgressBarCompletedBlockSymbol { get; set; }

        /// <summary>
        /// Term progress bar uncompleted block symbol.
        /// </summary>
        char ProgressBarUncompletedBlockSymbol { get; set; }

        /// <summary>
        /// Term progress bar blocks total.
        /// </summary>
        int ProgressBarBlocksTotal { get; set; }
    }
}