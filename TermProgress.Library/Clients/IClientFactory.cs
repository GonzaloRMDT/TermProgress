namespace TermProgress.Library.Clients
{
    /// <summary>
    /// <c>IClientFactory</c> interface.
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Creates client instance.
        /// </summary>
        /// <param name="clientType">Type of client to create.</param>
        /// <returns>Client instance.</returns>
        IClient Create(ClientType clientType);
    }
}