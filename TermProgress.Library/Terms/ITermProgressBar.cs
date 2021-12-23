namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for term progress bars.
    /// </summary>
    public interface ITermProgressBar
    {
        /// <summary>
        /// Composes term progress bar.
        /// </summary>
        /// <returns>Term progress bar.</returns>
        string Compose();
    }
}