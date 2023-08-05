using Microsoft.Extensions.Options;
using System;
using System.Text;
using TermProgress.Library.Options;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term.
    /// </summary>
    public class Term : ITerm
    {
        public int ElapsedDays => (DateTime.Now.Date - StartingDate).Days;
        public DateTime EndingDate => termOptions.Value.EndingDateTime.Date;
        public double Progress => (double)ElapsedDays / TotalDays;
        public int RemainingDays => (EndingDate - DateTime.Now.Date).Days;
        public DateTime StartingDate => termOptions.Value.StartingDateTime.Date;
        public int TotalDays => (EndingDate - StartingDate).Days;

        private readonly IOptions<TermOptions> termOptions;
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="termOptions">A <see cref="IOptions{T}"/> implementation with a generic type argument of <see cref="TermOptions"/>.</param>
        public Term(IOptions<TermOptions> termOptions)
        {
            this.termOptions = termOptions;
        }

        public override string ToString()
        {
            string progressBar = GetProgressBar();
            string progressPercentage = GetProgressPercentage();
            string daysCount = GetDaysCount();

            return $"{progressBar} {progressPercentage}\n\n{daysCount}";
        }

        /// <summary>
        /// Gets the progress bar <see cref="string"/>.
        /// </summary>
        /// <returns>The progress bar <see cref="string"/>.</returns>
        public string GetProgressBar()
        {
            const int BlocksTotal = 15;
            double daysPerBlock = (double) TotalDays / BlocksTotal;
            StringBuilder progressBar = new StringBuilder(BlocksTotal);

            for (int block = 1; block <= BlocksTotal; block++)
            {
                if ((block * daysPerBlock) <= ElapsedDays)
                {
                    progressBar.Append('▓');
                }
                else
                {
                    progressBar.Append('░');
                }
            }

            return progressBar.ToString();
        }

        /// <summary>
        /// Gets the progress bar percentage <see cref="string"/>.
        /// </summary>
        /// <returns>The progress bar percentage <see cref="string"/>.</returns>
        public string GetProgressPercentage()
        {
            return string.Format("{0:P2}", Progress);
        }

        /// <summary>
        /// Gets the days count <see cref="string"/>.
        /// </summary>
        /// <returns>The days count <see cref="string"/>.</returns>
        public string GetDaysCount()
        {
            return $"{ElapsedDays}/{RemainingDays}/{TotalDays}";
        }
    }
}
