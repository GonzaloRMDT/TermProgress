using TermProgress.Application.Publishers.Dtos.Requests;
using TermProgress.Application.Publishers.Dtos.Responses;

namespace TermProgress.Application.Publishers
{
    // TODO: Simplify interface name.

    /// <summary>
    /// Defines the common structure for term progress publishing services.
    /// </summary>
    public interface ITermProgressPublishingService
    {
        /// <summary>
        /// Creates term progress status on given social network asynchronously.
        /// </summary>
        /// <param name="request">The status creation request.</param>
        /// <returns>The status creation response..</returns>
        Task<CreateStatusResponseDto> CreateStatusAsync(CreateStatusRequestDto request);
    }
}