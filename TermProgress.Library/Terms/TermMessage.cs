namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term message.
    /// </summary>
    public class TermMessage : ITermMessage
    {
        private readonly ITerm term;
        private readonly ITermProgressBar termProgressBar;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="term">A <see cref="ITerm"/> implementation.</param>
        /// <param name="termProgressBar">A <see cref="ITermProgressBar"/> implementation.</param>
        public TermMessage(ITerm term, ITermProgressBar termProgressBar)
        {
            this.term = term;
            this.termProgressBar = termProgressBar;
        }

        public string Compose()
        {
            string progressBar = termProgressBar.Compose();
            string progressPercentage = string.Format("{0:P2}", term.Progress);
            return $"{progressBar} {progressPercentage}\n\n{term.ElapsedDays}/{term.RemainingDays}/{term.TotalDays}";
        }
    }
}
