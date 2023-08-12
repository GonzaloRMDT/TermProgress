using System.Threading.Tasks;
using TermProgress.Library.Clients;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Defines the common structure for publishing services.
    /// </summary>
    public interface IPublishingService
    {
        /// <summary>
        /// Publishes message on given social network asynchronously.
        /// </summary>
        /// <param name="network">Name of social network to publish on.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> instance with a generic type argument of <see cref="IMessage"/>.
        /// </returns>
        Task<IMessage> PublishAsync(string network);
    }
}