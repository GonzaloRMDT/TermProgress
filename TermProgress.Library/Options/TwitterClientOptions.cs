namespace TermProgress.Library.Options
{
    /// <summary>
    /// Represents the Twitter options.
    /// </summary>
    public class TwitterClientOptions
    {
        /// <summary>
        /// Gets or sets the Twitter access token.
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Gets or sets Twitter access token secret.
        /// </summary>
        public string? AccessTokenSecret { get; set; }

        /// <summary>
        /// Gets or sets Twitter bearer token.
        /// </summary>
        public string? BearerToken { get; set; }

        /// <summary>
        /// Gets or sets Twitter consumer key.
        /// </summary>
        public string? ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets Twitter consumer secret.
        /// </summary>
        public string? ConsumerSecret { get; set; }
    }
}
