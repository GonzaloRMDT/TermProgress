using System;
using System.Threading.Tasks;
using TermProgress.Library.Clients;
using TermProgress.Library.Terms;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Status creation service.
    /// </summary>
    /// <inheritdoc />
    public class StatusCreationService : IStatusCreationService
    {
        /// <summary>
        /// Client factory instance.
        /// </summary>
        private readonly IClientFactory _clientFactory;

        /// <summary>
        /// Term message instance.
        /// </summary>
        private readonly ITermMessage _termMessage;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="clientFactory">Client factory instance.</param>
        /// <param name="termMessage">Term message instance.</param>
        public StatusCreationService(IClientFactory clientFactory, ITermMessage termMessage)
        {
            _clientFactory = clientFactory;
            _termMessage = termMessage;
        }

        public async Task<SocialNetworkStatus> CreateStatusAsync(ClientType clientType)
        {
            IClient client = _clientFactory.Create(clientType);
            string termMessage = _termMessage.Compose();
            return await client.CreateStatusAsync(termMessage);
        }
    }
}