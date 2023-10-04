namespace TermProgress.Application.Publishers.Dtos.Responses
{
    /// <summary>
    /// Represents a status data transfer object.
    /// </summary>
    public record class StatusDto
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
