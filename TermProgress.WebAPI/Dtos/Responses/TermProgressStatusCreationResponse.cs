namespace TermProgress.WebAPI.Dtos.Responses
{
    /// <summary>
    /// Represents a term progress status creation response.
    /// </summary>
    public record class TermProgressStatusCreationResponse
    {
        /// <summary>
        /// Gets or initializes the created status ID.
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// Gets or initializes the created status text.
        /// </summary>
        public required string Text { get; init; }
    }
}
