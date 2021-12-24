using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProgress.Library.Clients;
using TermProgress.Library.Terms;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Represents a publishing service.
    /// </summary>
    public class PublishingService : IPublishingService
    {
        private readonly IEnumerable<IClient<IMessage>> clients;
        private readonly ITermMessage termMessage;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="clients">
        /// A <see cref="IEnumerable{T}"/> of <see cref="IClient{TMessage}"/> implementation
        /// with a generic type argument of <see cref="IMessage"/>.
        /// </param>
        /// <param name="termMessage">A <see cref="ITermMessage"/> implementation.</param>
        public PublishingService(IEnumerable<IClient<IMessage>> clients, ITermMessage termMessage)
        {
            this.clients = clients;
            this.termMessage = termMessage;
        }

        public async Task<IMessage> PublishAsync(string network)
        {
            string text = termMessage.Compose();
            IClient<IMessage> client = clients
                .Where(client =>
                {
                    return string.Equals(client.GetType().Name, network + "client", System.StringComparison.OrdinalIgnoreCase);
                })
                .Single();

            client.SetClient();
            return await client.CreateMessageAsync(text);
        }
    }
}
