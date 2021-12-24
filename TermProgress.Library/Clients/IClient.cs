using System.Threading.Tasks;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Defines the common structure for clients.
    /// </summary>
    /// <typeparam name="TMessage">A <see cref="IMessage"/> implementation.</typeparam>
    public interface IClient<TMessage> where TMessage : IMessage
    {
        /// <summary>
        /// Creates message asynchronously.
        /// </summary>
        /// <param name="text">Text of message to create.</param>
        /// <returns>A <see cref="Task{T}"/> instance with a generic type argument of <typeparamref name="TMessage"/>.</returns>
        Task<TMessage> CreateMessageAsync(string text);

        /// <summary>
        /// Deletes message asynchronously.
        /// </summary>
        /// <param name="id">ID of message to delete.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        Task DeleteMessageAsync(long id);

        /// <summary>
        /// Favorites message asynchronously.
        /// </summary>
        /// <param name="id">ID of message to favorite.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        Task FavoriteMessageAsync(long id);

        /// <summary>
        /// Reads message asynchronously.
        /// </summary>
        /// <param name="id">ID of message to read.</param>
        /// <returns>A <see cref="Task{TMessage}"/> instance with a generic type argument of <typeparamref name="TMessage"/>.</returns>
        Task<TMessage> ReadMessageAsync(long id);

        /// <summary>
        /// Sets clients.
        /// </summary>
        void SetClient();

        /// <summary>
        /// Shares message asynchronously.
        /// </summary>
        /// <param name="id">ID of message to share.</param>
        /// <returns>A <see cref="Task{TMessage}"/> instance with a generic type argument of <typeparamref name="TMessage"/>.</returns>
        Task<TMessage> ShareMessageAsync(long id);

        /// <summary>
        /// Unfavorites message asynchronously.
        /// </summary>
        /// <param name="id">ID of message to unfavorite.</param>
        Task UnfavoriteMessageAsync(long id);

        /// <summary>
        /// Unshares message asynchronously.
        /// </summary>
        /// <param name="id">ID of message to unshare.</param>
        Task UnshareMessageAsync(long id);
    }
}
