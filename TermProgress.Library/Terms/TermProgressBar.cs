using System;
using System.Text;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term message progress bar.
    /// </summary>
    public class TermProgressBar : ITermProgressBar
    {
        private const int blocksTotal = 15;
        private readonly ITerm term;
        private readonly ITermProgressBarBlockFactory termProgressBarBlockFactory;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="term">A <see cref="ITerm"/> implementation.</param>
        /// <param name="termProgressBarBlockFactory">A <see cref="ITermProgressBarBlockFactory"/> implementation.</param>
        public TermProgressBar(ITerm term, ITermProgressBarBlockFactory termProgressBarBlockFactory)
        {
            this.term = term;
            this.termProgressBarBlockFactory = termProgressBarBlockFactory;
        }

        /// <summary>
        /// Composes progress bar.
        /// </summary>
        /// <returns>Progress bar.</returns>
        public string Compose()
        {
            StringBuilder progressBar = new StringBuilder(blocksTotal);
            double progressBarBlockDays = (double)term.TotalDays / blocksTotal;
            double accumulatedDays = 0;

            for (int i = 0; i < blocksTotal; i++)
            {
                accumulatedDays += progressBarBlockDays;
                TermProgressBarBlock progressBarBlock = termProgressBarBlockFactory.CreateProgressBarBlock(Math.Floor(accumulatedDays), term.ElapsedDays);
                progressBar.Append(progressBarBlock.Symbol);
            }

            return progressBar.ToString();
        }
    }
}