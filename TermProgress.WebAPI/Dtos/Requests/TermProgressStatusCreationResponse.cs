using System;

namespace TermProgress.WebAPI.Dtos.Requests
{
    /// <summary>
    /// Represents a term progress status creation request.
    /// </summary>
    public record class TermProgressStatusCreationRequest
    {
        /// <summary>
        /// Gets or initializes the start date.
        /// </summary>
        public required DateTime StartDate { get; init; }

        /// <summary>
        /// Gets or initializes the end date.
        /// </summary>
        public required DateTime EndDate { get; init; }
    }
}
