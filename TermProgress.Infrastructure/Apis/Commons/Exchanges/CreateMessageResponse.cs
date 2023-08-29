namespace TermProgress.Infrastructure.Apis.Commons.Exchanges
{
    /// <summary>
    /// Represents a create message response.
    /// </summary>
    public record class CreateMessageResponse
    {
        public required string Id { get; init; }
        public required string Text { get; init; }
    }
}