using System;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a social network message.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets or sets the message ID.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the message text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the message creation <see cref="DateTime"/>.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the message network.
        /// </summary>
        public string Network { get; set; }
    }
}
