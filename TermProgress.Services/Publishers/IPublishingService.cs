using TermProgress.Application.Publishers.Dtos.Requests;
using TermProgress.Application.Publishers.Dtos.Responses;

namespace TermProgress.Application.Publishers
{
    /// <summary>
    /// Defines the common structure for publishing services.
    /// </summary>
    public interface IPublishingService
    {
        /// <summary>
        /// Creates term progress status on given social network asynchronously.
        /// </summary>
        /// <param name="request">The status creation request.</param>
        /// <returns>The status creation response..</returns>
        Task<CreateStatusResponseDto> CreateStatusAsync(CreateStatusRequestDto request);
    }
}