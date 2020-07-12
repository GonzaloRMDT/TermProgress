using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents a Twitter client configuration.
    /// </summary>
    public class TwitterClientConfiguration
    {
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
