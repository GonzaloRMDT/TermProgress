using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Exchanges;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;
using TermProgress.Library.Terms;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Represents a term progress service.
    /// </summary>
    public class TermProgressService : ITermProgressService
    {
        private readonly IEnumerable<IApiClient> apiClients;
        private readonly ITermMessage termMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressService"/> class.
        /// </summary>
        /// <param name="apiClients">
        /// An <see cref="IEnumerable{T}"/> with a generic type argument of <see cref="IApiClient"/>.
        /// </param>
        /// <param name="termMessage">A <see cref="ITermMessage"/> implementation.</param>
        public TermProgressService(IEnumerable<IApiClient> apiClients, ITermMessage termMessage)
        {
            this.apiClients = apiClients;
            this.termMessage = termMessage;
        }

        public async Task<CreateMessageResponse?> CreateAsync(string network)
        {
            IApiClient apiClient = apiClients
                .Where(apiClient =>
                {
                    return string.Equals(apiClient.GetType().Name, network + "ApiClient", System.StringComparison.OrdinalIgnoreCase);
                })
                .Single();

            string message = termMessage.ToString()!;

            return await apiClient.CreateMessageAsync(message);
        }
    }
}
