using System;
using Microsoft.Extensions.Options;
using TermProgress.Library.Configurations;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term progress bar block factor.
    /// </summary>
    /// <inheritdoc />
    public class TermProgressBarBlockFactory : ITermProgressBarBlockFactory
    {
        /// <summary>
        /// Term configuration.
        /// </summary>
        private readonly TermConfiguration _termConfiguration;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public TermProgressBarBlockFactory(IOptions<TermConfiguration> termConfiguration)
        {
            _termConfiguration = termConfiguration.Value;
        }

        public TermProgressBarBlock CreateProgressBarBlock(double progressBarBlockDays, double elapsedDays)
        {
            return progressBarBlockDays <= elapsedDays ? CreateCompletedProgressBarBlock() : CreateUncompletedProgressBarBlock();
        }

        private TermProgressBarBlock CreateCompletedProgressBarBlock()
        {
            return new TermProgressBarBlock
            {
                Type = TermProgressBarBlockType.Completed,
                Symbol = _termConfiguration.ProgressBarCompletedSymbol
            };
        }

        private TermProgressBarBlock CreateUncompletedProgressBarBlock()
        {
            return new TermProgressBarBlock
            {
                Type = TermProgressBarBlockType.Uncompleted,
                Symbol = _termConfiguration.ProgressBarUncompletedSymbol
            };
        }
    }
}