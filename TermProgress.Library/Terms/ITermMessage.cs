namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for term messages.
    /// </summary>
    public interface ITermMessage
    {
        /// <summary>
        /// Gets the term.
        /// </summary>
        ITerm Term { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns>The message.</returns>
        string GetMessage();

        /// <summary>
        /// Gets the progress bar.
        /// </summary>
        /// <returns>The progress bar.</returns>
        string GetProgressBar();

        /// <summary>
        /// Gets the progress day summary.
        /// </summary>
        /// <returns>The progress day summary.</returns>
        string GetProgressDaySummary();

        /// <summary>
        /// Gets the progress percentage.
        /// </summary>
        /// <returns>The progress percentage.</returns>
        string GetProgressPercentage();
    }
}