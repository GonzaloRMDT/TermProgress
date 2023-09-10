using System;

namespace TermProgress.Functions.Options
{
    /// <summary>
    /// Represents the Azure Function options.
    /// </summary>
    public record FunctionOptions
    {
        /// <summary>
        /// Gets or sets the application API key.
        /// </summary>
        public string? ApiKey { get; init; }

        /// <summary>
        /// Gets or sets the term end date.
        /// </summary>
        public DateTime? EndDate { get; init; }

        /// <summary>
        /// Gets or sets the term start date.
        /// </summary>
        public DateTime? StartDate { get; init; }

        /// <summary>
        /// Gets or sets the Term Progress API base URL.
        /// </summary>
        public string? TermProgressApiBaseUrl { get; init; }
    }
}
