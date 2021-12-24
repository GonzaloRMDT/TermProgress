using System;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a social network message.
    /// </summary>
    /// <inheritdoc/>
    public class Message : IMessage
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Network { get; set; }
    }
}