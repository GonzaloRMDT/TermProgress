using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using TermProgress.Infrastructure.Apis.Commons.Entities;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;
using TermProgress.Infrastructure.Apis.Twitter.Entities;

namespace TermProgress.Infrastructure.Apis.Twitter
{
    /// <summary>
    /// Represents a Twitter API client.
    /// </summary>
    public class TwitterApiClient : IApiClient
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

        public void Dispose()
        {
            apiClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse<Status>> CreateStatusAsync(string text)
        {
            var request = new RestRequest("2/tweets").AddJsonBody(new { text });
            var response = await apiClient.ExecutePostAsync<TwitterObject<TwitterStatus>>(request);
            var statusResponse = RestResponse<Status>.FromResponse(response);
            if (response.IsSuccessful)
            {
                statusResponse.Data = new Status
                {
                    Id = response.Data!.Data.Id,
                    Text = response.Data!.Data.Text
                };
            }

            return statusResponse;
        }
    }
}
