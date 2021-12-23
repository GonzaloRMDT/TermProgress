using System.Threading.Tasks;
using TermProgress.Library.Clients;
using TermProgress.Library.Terms;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Represents a status creation service.
    /// </summary>
    /// <inheritdoc />
    public class StatusCreationService : IStatusCreationService
    {
        private readonly IClientFactory clientFactory;
        private readonly ITermMessage termMessage;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="clientFactory">A <see cref="IClientFactory"/> implementation.</param>
        /// <param name="termMessage">A <see cref="ITermMessage"/> implementation.</param>
        public StatusCreationService(IClientFactory clientFactory, ITermMessage termMessage)
        {
            this.clientFactory = clientFactory;
            this.termMessage = termMessage;
        }

        public async Task<SocialNetworkStatus> CreateStatusAsync(ClientType clientType)
        {
            IClient client = clientFactory.Create(clientType);
            string termMessage = this.termMessage.Compose();
            return await client.CreateStatusAsync(termMessage);
        }
    }
}