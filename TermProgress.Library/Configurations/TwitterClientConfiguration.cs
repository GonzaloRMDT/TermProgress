using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents a Twitter client configuration.
    /// </summary>
    public class TwitterClientConfiguration
    {
        /// <summary>
        /// Name of client class to set.
        /// </summary>
        public string ClientClassName { get; set; }

        /// <summary>
        /// Rate limit window, measured in seconds.
        /// </summary>
        public string RateLimitWindowInSeconds { get; set; }

        /// <summary>
        /// Maximum number of requests per rate limit window.
        /// </summary>
        public string MaxRequestsPerRateLimitWindow { get; set; }

        /// <summary>
        /// Maximum number of characters allowed for a single status.
        /// </summary>
        public string StatusCharacterLimit { get; set; }

        /// <summary>
        /// Client access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Client access token secret.
        /// </summary>
        public string AccessTokenSecret { get; set; }

        /// <summary>
        /// Client consumer key.
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Client consumer key.
        /// </summary>
        public string ConsumerSecret { get; set; }
    }
}
