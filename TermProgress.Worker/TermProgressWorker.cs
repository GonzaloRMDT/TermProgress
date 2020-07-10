using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TermProgress.Library.Authentications;

namespace TermProgress.Worker
{
    public static class TermProgressWorker
    {
        #region << Constants >>

        /// <summary>
        /// Application authentication endpoint URL.
        /// </summary>
        private const string ApplicationAuthenticationEndpointUrl = "APPLICATION_AUTHENTICATION_ENDPOINT_URL";

        /// <summary>
        /// Application admin username.
        /// </summary>
        private const string ApplicationAdminUsername = "APPLICATION_ADMIN_USERNAME";

        /// <summary>
        /// Application admin password.
        /// </summary>
        private const string ApplicationAdminPassword = "APPLICATION_ADMIN_PASSWORD";

        /// <summary>
        /// Twitter status creation endpoint URL.
        /// </summary>
        private const string TwitterStatusCreationEndpointUrl = "TWITTER_STATUS_CREATION_ENDPOINT_URL";

        #endregion

        #region << Fields >>

        /// <summary>
        /// Logger instance.
        /// </summary>
        private static ILogger _logger;

        /// <summary>
        /// HTTP client instance.
        /// </summary>
        private static HttpClient _httpClient;

        #endregion

        #region << Public methods >>

        /// <summary>
        /// Runs worker asynchronously.
        /// </summary>
        /// <param name="myTimer">Timer instance.</param>
        /// <param name="logger">Logger instance.</param>
        /// <remarks>Asynchronous method.</remarks>
        [FunctionName("TermProgressWorker")]
        public static async Task Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, ILogger logger)
        {
            // Set fields
            _logger = logger;
            _httpClient = new HttpClient();

            // Create status
            var tokenResponse = await RequestUserAuthenticationTokenAsync();
            await RequestTwitterStatusCreationAsync(tokenResponse.Token);

            // Dispose HTTP client
            _httpClient.Dispose();
        }

        /// <summary>
        /// Requests user authentication token asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <returns>Task object with <c>TokenResponse</c> instance.</returns>
        private static async Task<TokenResponse> RequestUserAuthenticationTokenAsync()
        {
            var userCredentials = new UserCredentials
            {
                Username = GetEnvironmentVariable(ApplicationAdminUsername),
                Password = GetEnvironmentVariable(ApplicationAdminPassword)
            };

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, GetEnvironmentVariable(ApplicationAuthenticationEndpointUrl)))
            using (var httpContent = CreateHttpContent(userCredentials))
            {
                httpRequestMessage.Content = httpContent;

                using (var response = await _httpClient
                    .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    _logger.LogInformation("Requested user authentication token.");
                    response.EnsureSuccessStatusCode();
                    var token = await response.Content.ReadAsAsync<TokenResponse>();
                    return token;
                }
            }
        }

        /// <summary>
        /// Requests Twitter status creation asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="token">Authentication token.</param>
        /// <returns>Empty <c>Task</c> object.</returns>
        private static async Task RequestTwitterStatusCreationAsync(string token)
        {
            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, GetEnvironmentVariable(TwitterStatusCreationEndpointUrl)))
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await _httpClient
                    .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    _logger.LogInformation("Requested Twitter status creation.");
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        #endregion

        #region << Private methods >>

        private static HttpContent CreateHttpContent(object content)
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

        private static void SerializeJsonIntoStream(object content, MemoryStream memoryStream)
        {
            using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(false), 1024, true))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.None })
            {
                var jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(jsonTextWriter, content);
                jsonTextWriter.Flush();
            }
        }

        private static string GetEnvironmentVariable(string environmentVariableName)
        {
            return Environment.GetEnvironmentVariable(environmentVariableName);
        }

        #endregion
    }
}