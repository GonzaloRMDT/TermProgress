namespace TermProgress.Application.Publishers.Dtos.Requests
{
    /// <summary>
    /// Represents a status creation request data transfer object.
    /// </summary>
    public record class CreateStatusRequestDto
    {
        /// <summary>
        /// Gets or initializes the start date.
        /// </summary>
        public DateTime StartDate { get; init; }

        /// <summary>
        /// Gets or initializes the end date.
        /// </summary>
        public DateTime EndDate { get; init; }
    }
}
