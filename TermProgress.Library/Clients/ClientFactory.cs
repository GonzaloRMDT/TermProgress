using System;
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
        /// <summary>
        /// Clients enumeration.
        /// </summary>
        IEnumerable<IClient> _clients;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public ClientFactory(IEnumerable<IClient> clients)
        {
            _clients = clients;
        }

        public IClient Create(ClientType clientType)
        {
            var clientName = clientType.ToString() + "Client";
            return _clients.First(client => client.GetType().Name == clientName);
        }
    }
}
