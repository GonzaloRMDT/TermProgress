namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Defines the common structure for client factories.
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Creates client instance.
        /// </summary>
        /// <param name="clientType">Type of client to create.</param>
        /// <returns>A <see cref="IClient"/> implementation.</returns>
        IClient Create(ClientType clientType);
    }
}