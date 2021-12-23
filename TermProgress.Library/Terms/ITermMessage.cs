namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Defines the common structure for term messages.
    /// </summary>
    public interface ITermMessage
    {
        /// <summary>
        /// Composes term message.
        /// </summary>
        /// <returns>Term message.</returns>
        string Compose();
    }
}