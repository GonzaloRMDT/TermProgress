using System;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term message.
    /// </summary>
    public class TermMessage : ITermMessage
    {
        /// <summary>
        /// Term instance.
        /// </summary>
        /// <inheritdoc />
        private readonly ITerm _term;

        /// <summary>
        /// Term progress bar instance.
        /// </summary>
        private readonly ITermProgressBar _termProgressBar;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="term">Term instance.</param>
        public TermMessage(ITerm term, ITermProgressBar termProgressBar)
        {
            _term = term;
            _termProgressBar = termProgressBar;
        }

        public string Compose()
        {
            string progressBar = _termProgressBar.Compose();
            string progressPercentage = string.Format("{0:P2}", _term.Progress);
            return $"{progressBar} {progressPercentage}\n\n{_term.ElapsedDays}/{_term.RemainingDays}/{_term.TotalDays}";
        }
    }
}
