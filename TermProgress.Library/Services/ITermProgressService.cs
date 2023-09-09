using System;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Exchanges;

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
        /// A <see cref="Task{T}"/> instance with a generic type argument of <see cref="StatusCreationResponse"/>.
        /// </returns>
        Task<StatusCreationResponse?> CreateStatusAsync(string network, DateTime startDate, DateTime endDate);
    }
}