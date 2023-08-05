using System;
using System.Text;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term message.
    /// </summary>
    public class TermMessage : ITermMessage
    {
        private readonly ITerm term;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="term">A <see cref="ITerm"/> implementation.</param>
        public TermMessage(ITerm term)
        {
            this.term = term;
        }

        public override string ToString()
        {
            string days = $"{term.ElapsedDays}/{term.RemainingDays}/{term.TotalDays}";
            string percentage = string.Format("{0:P2}", term.Progress);

            return $"{GetBar()} {percentage}\n\n{days}";
        }

        private string GetBar()
        {
            const int BlocksTotal = 15;
            double daysPerBlock = (double)term.TotalDays / BlocksTotal;
            StringBuilder progressBar = new StringBuilder(BlocksTotal);

            for (int block = 1; block <= BlocksTotal; block++)
            {
                if ((block * daysPerBlock) <= term.ElapsedDays)
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

    }
}
