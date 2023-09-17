namespace TermProgress.Infrastructure.Apis.Commons.Entities
{
    /// <summary>
    /// Represents a status.
    /// </summary>
    public record class Status
    {
        /// <summary>
        /// Gets or initializes the status ID.
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// Gets or initializes the status text.
        /// </summary>
        public required string Text { get; init; }
    }
}
