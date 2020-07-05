using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents a Twitter client configuration.
    /// </summary>
    public class TwitterClientConfiguration
    {
        /// <summary>
        /// Gets or sets the rate limit window, measured in seconds.
        /// </summary>
        public string RateLimitWindowInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of requests per rate limit window.
        /// </summary>
        public string MaxRequestsPerRateLimitWindow { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of characters allowed for a single status.
        /// </summary>
        public string StatusCharacterLimit { get; set; }

        /// <summary>
        /// Gets or sets the client access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the client access token secret.
        /// </summary>
        public string AccessTokenSecret { get; set; }

        /// <summary>
        /// Gets or sets the client consumer key.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the client consumer key.
        /// </summary>
        public string ConsumerSecret { get; set; }
    }
}
