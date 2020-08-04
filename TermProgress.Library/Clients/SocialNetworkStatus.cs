using System;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a social network status.
    /// </summary>
    public class SocialNetworkStatus
    {
        /// <summary>
        /// Status creation date and time.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Status text.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Status URL.
        /// </summary>
        public string Url { get; set; }
    }
}
