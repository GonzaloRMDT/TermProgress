using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Threading.Tasks;
using TermProgress.Functions.Options;

namespace TermProgress.Functions.Clients
{
    /// <summary>
    /// Represents a term progress API client.
    /// </summary>
    /// <inheritdoc />
    public class TermProgressApiClient : ITermProgressApiClient
    {
        private readonly RestClient apiClient;
        private readonly FunctionOptions functionOptions;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="functionOptions">
        /// A <see cref="IOptions{TOptions}"/> implementation
        /// with a generic argument type of <see cref="FunctionOptions"/>.
        /// </param>
        public TermProgressApiClient(IOptions<FunctionOptions> functionOptions)
        {
            this.functionOptions = functionOptions.Value;
            apiClient = new RestClient(this.functionOptions.TermProgressApiBaseUrl!);
        }

        public void Dispose()
        {
            apiClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task RequestStatusCreationAsync(DateTime startDate, DateTime endDate)
        {
            RestRequest request = new RestRequest("api/v1/termprogress/twitter")
                .AddHeader("ApiKey", functionOptions.ApiKey!)
                .AddJsonBody(new { startDate, endDate });

            await apiClient.ExecutePostAsync(request);
        }
    }
}
