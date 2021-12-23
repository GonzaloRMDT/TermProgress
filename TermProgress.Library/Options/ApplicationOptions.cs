namespace TermProgress.Library.Options
{
    /// <summary>
    /// Represents the application options.
    /// </summary>
    public class ApplicationOptions
    {
        /// <summary>
        /// Gets or sets the admin password.
        /// </summary>
        public string AdminPassword { get; set; }

        /// <summary>
        /// Gets or sets the admin user name.
        /// </summary>
        public string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the application culture.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        public string Version { get; set; }
    }
}
