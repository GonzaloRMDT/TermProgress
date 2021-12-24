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
        private readonly ITerm term;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="clients">
        /// A <see cref="IEnumerable{T}"/> of <see cref="IClient{TMessage}"/> implementation
        /// with a generic type argument of <see cref="IMessage"/>.
        /// </param>
        /// <param name="term">A <see cref="ITerm"/> implementation.</param>
        public PublishingService(IEnumerable<IClient<IMessage>> clients, ITerm term)
        {
            this.clients = clients;
            this.term = term;
        }

        public async Task<IMessage> PublishAsync(string network)
        {
            string text = term.ToString();

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
