using System;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a social network status.
    /// </summary>
    public class SocialNetworkStatus
    {
        /// <summary>
        /// Gets or sets the status creation <see cref="DateTime"/>.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the status URL.
        /// </summary>
        public string Url { get; set; }
    }
}
