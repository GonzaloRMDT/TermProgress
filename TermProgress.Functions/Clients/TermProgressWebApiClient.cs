using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TermProgress.Functions.Options;

namespace TermProgress.Functions.Clients
{
    /// <summary>
    /// Represents a term progress web API client.
    /// </summary>
    /// <inheritdoc />
    public class TermProgressWebApiClient : ITermProgressWebApiClient
    {
        private readonly IOptions<ApplicationOptions> applicationOptions;
        private readonly HttpClient httpClient;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="applicationOptions">A <see cref="IOptions{TOptions}"/> implementation with a generic argument type of <see cref="ApplicationOptions"/>.</param>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance.</param>
        public TermProgressWebApiClient(IOptions<ApplicationOptions> applicationOptions, HttpClient httpClient)
        {
            this.applicationOptions = applicationOptions;
            this.httpClient = httpClient;
        }

        public async Task RequestPublishingAsync(string apiKey)
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, applicationOptions.Value.PublishingEndpointUrl))
            {
                httpRequestMessage.Headers.Add("ApiKey", apiKey);

                using (var response = await httpClient
                    .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
