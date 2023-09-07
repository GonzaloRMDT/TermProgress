using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Threading.Tasks;
using TermProgress.Functions.Options;

namespace TermProgress.Functions.Clients
{
    /// <summary>
    /// Represents a term progress web API client.
    /// </summary>
    /// <inheritdoc />
    public class TermProgressApiClient : ITermProgressApiClient
    {
        private readonly RestClient apiClient;
        private readonly ApplicationOptions applicationOptions;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="applicationOptions">A <see cref="IOptions{TOptions}"/> implementation with a generic argument type of <see cref="ApplicationOptions"/>.</param>
        ///
        public TermProgressApiClient(IOptions<ApplicationOptions> applicationOptions)
        {
            this.applicationOptions = applicationOptions.Value;
            apiClient = new RestClient(this.applicationOptions.TermProgressApiBaseUrl!);
        }

        public void Dispose()
        {
            apiClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task RequestMessageCreationAsync()
        {
            RestRequest request = new RestRequest("api/v1/termprogress/twitter")
                .AddHeader("ApiKey", applicationOptions.ApiKey!);
            await apiClient.ExecutePostAsync(request);
        }
    }
}
