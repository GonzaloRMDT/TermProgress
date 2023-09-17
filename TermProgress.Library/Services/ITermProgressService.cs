using System;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Entities;
using TermProgress.Library.Services.Models;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Defines the common structure for term progress services.
    /// </summary>
    public interface ITermProgressService
    {
        /// <summary>
        /// Creates term progress status on given social network asynchronously.
        /// </summary>
        /// <param name="network">Name of social network to publish on.</param>
        /// <param name="startDate">The term start date.</param>
        /// <param name="endDate">The term end date.</param>
        /// <returns>
        /// The response with the created status.
        /// </returns>
        Task<Response<Status>> CreateStatusAsync(string network, DateTime startDate, DateTime endDate);
    }
}