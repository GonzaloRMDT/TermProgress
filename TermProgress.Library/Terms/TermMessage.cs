using System.Text;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term message.
    /// </summary>
    public class TermMessage : ITermMessage
    {
        public ITerm Term { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="term">A <see cref="ITerm"/> implementation.</param>
        public TermMessage(ITerm term)
        {
            Term = term;
        }

        public override string? ToString()
        {
            string days = $"{Term.ElapsedDays}/{Term.RemainingDays}/{Term.TotalDays}";
            string percentage = string.Format("{0:P2}", Term.Progress);

            return $"{GetBar()} {percentage}\n\n{days}";
        }

        /// <summary>
        /// Gets the progress bar.
        /// </summary>
        /// <returns>The progress bar.</returns>
        public string GetBar()
        {
            const int BlocksTotal = 15;
            double daysPerBlock = (double)Term.TotalDays / BlocksTotal;
            StringBuilder progressBar = new StringBuilder(BlocksTotal);

            for (int block = 1; block <= BlocksTotal; block++)
            {
                if ((block * daysPerBlock) <= Term.ElapsedDays)
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
