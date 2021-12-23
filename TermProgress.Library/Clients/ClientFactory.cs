using System.Collections.Generic;
using System.Linq;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Client factory.
    /// </summary>
    /// <inheritdoc />
    public class ClientFactory : IClientFactory
    {
        private readonly IEnumerable<IClient> clients;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="clients">An <see cref="IEnumerable{T}"/> of <typeparamref name="IClient"/>.</param>
        public ClientFactory(IEnumerable<IClient> clients)
        {
            this.clients = clients;
        }

        public IClient Create(ClientType clientType)
        {
            var clientName = clientType.ToString() + "Client";
            return clients.First(client => client.GetType().Name == clientName);
        }
    }
}
