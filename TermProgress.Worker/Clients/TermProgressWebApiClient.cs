using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TermProgress.Library.Authentications;
using TermProgress.Functions.Configurations;

namespace TermProgress.Functions.Clients
{
    /// <summary>
    /// Represents a term progress web API client.
    /// </summary>
    /// <inheritdoc />
    public class TermProgressWebApiClient : ITermProgressWebApiClient
    {
        /// <summary>
        /// Application configuration.
        /// </summary>
        private readonly ApplicationConfiguration _applicationConfiguration;

        /// <summary>
        /// HTTP client instance.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="applicationConfiguration">Application configuration.</param>
        /// <param name="httpClient">HTTP client instance.</param>
        public TermProgressWebApiClient(IOptions<ApplicationConfiguration> applicationConfiguration, HttpClient httpClient)
        {
            _applicationConfiguration = applicationConfiguration.Value;
            _httpClient = httpClient;
        }

        #region << Public methods >>

        public async Task<TokenResponse> RequestUserAuthenticationTokenAsync()
        {
            var userCredentials = new UserCredentials
            {
                Username = _applicationConfiguration.ApplicationAdminUsername,
                Password = _applicationConfiguration.ApplicationAdminPassword
            };

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _applicationConfiguration.ApplicationAuthenticationEndpointUrl))
            using (var httpContent = CreateHttpContent(userCredentials))
            {
                httpRequestMessage.Content = httpContent;

                using (var response = await _httpClient
                    .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsAsync<TokenResponse>();
                }
            }
        }

        public async Task RequestTwitterStatusCreationAsync(string token)
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, _applicationConfiguration.TwitterStatusCreationEndpointUrl))
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await _httpClient
                    .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        #endregion

        #region << Private methods >>

        private HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var memoryStream = new MemoryStream();
                SerializeJsonIntoStream(content, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(memoryStream);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        private void SerializeJsonIntoStream(object content, MemoryStream memoryStream)
        {
            using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false), 1024, true))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
            {
                var jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(jsonTextWriter, content);
                jsonTextWriter.Flush();
            }
        }

        #endregion
    }
}
