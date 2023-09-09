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
        /// Initializes a new instance of the term message class.
        /// </summary>
        /// <param name="term">A <see cref="ITerm"/> implementation.</param>
        public TermMessage(ITerm term)
        {
            Term = term;
        }

        public override string? ToString()
        {
            return $"{GetProgressBar()} {GetProgressPercentage()} {GetProgressDaySummary()}";
        }

        public string GetMessage()
        {
            return $"{GetProgressBar()} {GetProgressPercentage()}\n\n{GetProgressDaySummary()}";
        }

        public string GetProgressBar()
        {
            const int BlocksTotal = 15;
            double daysPerBlock = (double)Term.GetDaysTotal() / BlocksTotal;
            var progressBar = new StringBuilder(BlocksTotal);
            for (int block = 1; block <= BlocksTotal; block++)
            {
                if ((block * daysPerBlock) <= Term.GetDaysElapsed())
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

        public string GetProgressDaySummary()
        {
            return $"{Term.GetDaysElapsed()}/{Term.GetDaysRemaining()}/{Term.GetDaysTotal()}";
        }

        public string GetProgressPercentage()
        {
            return string.Format("{0:P2}", Term.GetProgressRatio());
        }
    }
}
