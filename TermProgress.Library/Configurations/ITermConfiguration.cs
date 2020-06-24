using System;

namespace TermProgress.Library.Configurations
{
    public interface ITermConfiguration
    {
        DateTime StartingDateTime { get; set; }
        int DurationInYears { get; set; }

        // TODO: Rename to ProgressBarCompletionSymbol
        char ProgressBarCompletedSymbol { get; set; }

        // TODO: Rename to ProgressBarUncompletionSymbol
        char ProgressBarUncompletedSymbol { get; set; }
        int ProgressBarSymbolsTotal { get; set; }
    }
}