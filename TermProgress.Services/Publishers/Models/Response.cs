using TermProgress.Application.Publishers.Models.Enums;

namespace TermProgress.Application.Publishers.Models
{
    /// <summary>
    /// Represents a response.
    /// </summary>
    /// <typeparam name="T">The type of the data associated with this response.</typeparam>
    public record Response<T> where T : class
    {
        /// <summary>
        /// Gets or initializes the request result.
        /// </summary>
        public required RequestResult Result { get; init; }

        /// <summary>
        /// Gets or initializes the response data.
        /// </summary>
        public required T? Data { get; init; }
    }
}
