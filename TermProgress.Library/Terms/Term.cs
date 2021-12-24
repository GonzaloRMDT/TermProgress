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

        private string GetProgressBar()
        {
            int blocksTotal = 15;
            double daysPerBlock = (double) TotalDays / blocksTotal;
            StringBuilder progressBar = new StringBuilder(blocksTotal);

            for (int block = 1; block <= blocksTotal; block++)
            {
                if ((block * daysPerBlock) < ElapsedDays)
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

        private string GetProgressPercentage()
        {
            return string.Format("{0:P2}", Progress);
        }

        private string GetDaysCount()
        {
            return $"{ElapsedDays}/{RemainingDays}/{TotalDays}";
        }
    }
}
