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
        /// Creates message on given social network asynchronously.
        /// </summary>
        /// <param name="network">Name of social network to publish on.</param>
        /// <returns>
        /// A <see cref="Task{T}"/> instance with a generic type argument of <see cref="CreateMessageResponse"/>.
        /// </returns>
        Task<CreateMessageResponse?> CreateAsync(string network);
    }
}