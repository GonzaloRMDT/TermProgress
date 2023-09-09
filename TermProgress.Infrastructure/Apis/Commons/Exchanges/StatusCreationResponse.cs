namespace TermProgress.Infrastructure.Apis.Commons.Exchanges
{
    /// <summary>
    /// Represents a status creation response.
    /// </summary>
    public record class StatusCreationResponse
    {
        public required string Id { get; init; }
        public required string Text { get; init; }
    }
}