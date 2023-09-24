using TermProgress.Application.Publishers.Dtos;

namespace TermProgress.Application.Publishers
{
    /// <summary>
    /// Defines the common structure for term progress publishing services.
    /// </summary>
    public interface ITermProgressPublishingService
    {
        /// <summary>
        /// Creates term progress status on given social network asynchronously.
        /// </summary>
        /// <param name="network">Name of social network to publish on.</param>
        /// <param name="startDate">The term start date.</param>
        /// <param name="endDate">The term end date.</param>
        /// <returns>The response data transfer object with the created status.</returns>
        Task<ResponseDto<StatusDto>> CreateStatusAsync(string network, DateTime startDate, DateTime endDate);
    }
}