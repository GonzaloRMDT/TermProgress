using System.Text.Json.Serialization;
using TermProgress.Application.Publishers.Dtos.Enums;

namespace TermProgress.Application.Publishers.Dtos
{
    /// <summary>
    /// Represents a response data transfer object.
    /// </summary>
    /// <typeparam name="T">The type of the data associated with this response.</typeparam>
    public record ResponseDto<T> where T : class
    {
        /// <summary>
        /// Gets or initializes the request result.
        /// </summary>
        [JsonIgnore]
        public required RequestResult Result { get; init; }

        /// <summary>
        /// Gets or initializes the response data.
        /// </summary>
        public required T? Data { get; init; }
    }
}
