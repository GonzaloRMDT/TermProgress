namespace TermProgress.Domain.Options
{
    /// <summary>
    /// Represents the application options.
    /// </summary>
    public class ApplicationOptions
    {
        /// <summary>
        /// Gets or sets the application culture.
        /// </summary>
        public string? Culture { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        public string? Version { get; set; }
    }
}
