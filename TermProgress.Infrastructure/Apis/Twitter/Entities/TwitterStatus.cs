using System.Text.Json.Serialization;

namespace TermProgress.Infrastructure.Apis.Twitter.Entities
{
    /// <summary>
    /// Represents a Twitter status.
    /// </summary>
    public record class TwitterStatus
    {
        /// <summary>
        /// Gets or initializes the Twitter status ID..
        /// </summary>
        [JsonPropertyName("id")]
        public required string Id { get; init; }

        /// <summary>
        /// Gets or initializes the Twitter status edit history.
        /// </summary>
        [JsonPropertyName("edit_history_tweet_ids")]
        public required string[] EditHistoryTweetIds { get; init; }

        /// <summary>
        /// Gets or initializes the Twitter status text.
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; init; }
    }
}