using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using System.Text.Json;
using TermProgress.Infrastructure.Apis.Commons.Exchanges;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;

namespace TermProgress.Infrastructure.Apis.Twitter
{
    /// <summary>
    /// Represents a Twitter API client.
    /// </summary>
    public class TwitterApiClient : IApiClient, IDisposable
    {
        private readonly RestClient apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterApiClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerKeySecret">The consumer key secret.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="accessTokenSecret">The access token secret.</param>
        public TwitterApiClient(
            string consumerKey,
            string consumerKeySecret,
            string accessToken,
            string accessTokenSecret)
        {
            OAuth1Authenticator authenticator = OAuth1Authenticator.ForProtectedResource(
                consumerKey, consumerKeySecret, accessToken, accessTokenSecret,
                OAuthSignatureMethod.HmacSha1
            );

            var options = new RestClientOptions("https://api.twitter.com/")
            {
                Authenticator = authenticator
            };

            apiClient = new RestClient(options);
        }

        /// <summary>
        /// Disposes the client.
        /// </summary>
        public void Dispose()
        {
            apiClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<CreateMessageResponse?> CreateMessageAsync(string text)
        {
            RestRequest request = new RestRequest("2/tweets").AddJsonBody(new { text });
            RestResponse response = await apiClient.ExecutePostAsync(request);
            if (response.IsSuccessful && response.Content is not null)
            {
                try
                {
                    using JsonDocument responseJsonBody = JsonDocument.Parse(response.Content);
                    JsonElement responseJsonBodyData = responseJsonBody.RootElement.GetProperty("data");

                    return new CreateMessageResponse()
                    {
                        Id = responseJsonBodyData.GetProperty("id").GetString()!,
                        Text = responseJsonBodyData.GetProperty("text").GetString()!
                    };
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else { return null; }
        }
    }
}
