namespace TermProgress.Application.Publishers.Dtos
{
    /// <summary>
    /// Represents a status data transfer object.
    /// </summary>
    public class StatusDto
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
