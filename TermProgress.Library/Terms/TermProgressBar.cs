using System;
using System.Text;
using Microsoft.Extensions.Options;
using TermProgress.Library.Configurations;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term message progress bar.
    /// </summary>
    public class TermProgressBar : ITermProgressBar
    {
        /// <summary>
        /// Term configuration.
        /// </summary>
        private readonly TermConfiguration _termConfiguration;

        /// <summary>
        /// Term instance.
        /// </summary>
        private readonly ITerm _term;

        /// <summary>
        /// Term progress bar block factor.
        /// </summary>
        private readonly ITermProgressBarBlockFactory _termProgressBarBlockFactory;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="termConfiguration">Term configuration.</param>
        /// <param name="term">Term instance.</param>
        /// <param name="termProgressBarBlockFactory">Term progress bar block factory.</param>
        public TermProgressBar(IOptions<TermConfiguration> termConfiguration, ITerm term, ITermProgressBarBlockFactory termProgressBarBlockFactory)
        {
            _termConfiguration = termConfiguration.Value;
            _term = term;
            _termProgressBarBlockFactory = termProgressBarBlockFactory;
        }

        /// <summary>
        /// Composes progress bar.
        /// </summary>
        /// <returns>Progress bar.</returns>
        public string Compose()
        {
            StringBuilder progressBar = new StringBuilder(_termConfiguration.ProgressBarSymbolsTotal);
            double progressBarBlockUnitValue = 100d / _termConfiguration.ProgressBarSymbolsTotal;
            double comparisonProgress = 0;

            while (comparisonProgress <= 100)
            {
                TermProgressBarBlock progressBarBlock = _termProgressBarBlockFactory.CreateProgressBarBlock(comparisonProgress, _term.Progress);
                progressBar.Append(progressBarBlock.Symbol);
                comparisonProgress += progressBarBlockUnitValue;
            }

            return progressBar.ToString();
        }
    }
}