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
    }
}