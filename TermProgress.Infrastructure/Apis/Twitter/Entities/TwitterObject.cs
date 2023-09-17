using System.Text.Json.Serialization;

namespace TermProgress.Infrastructure.Apis.Twitter.Entities
{
    /// <summary>
    /// Represents a Twitter object.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    public record class TwitterObject<T> where T : class
    {
        /// <summary>
        /// Gets or initializes the data.
        /// </summary>
        [JsonPropertyName("data")]
        public required T Data { get; init; }
    }
}
