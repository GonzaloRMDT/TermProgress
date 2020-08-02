using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using TermProgress.Library.Configurations;
using Tweetinvi;
using Tweetinvi.Models;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a Twitter client.
    /// </summary>
    /// <inheritdoc />
    public class TwitterClient : SocialNetworkClient<TwitterClientConfiguration>, IClient
    {
        #region << Private fields >>

        /// <summary>
        /// Client credentials.
        /// </summary>
        private ITwitterCredentials _credentials;

        #endregion

        #region << Constructors >>

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="mapper">Mapper instance.</param>
        /// <param name="twitterClientConfiguration">Twitter client configuration.</param>
        public TwitterClient(IMapper mapper, IOptions<TwitterClientConfiguration> twitterClientConfiguration) : base(mapper, twitterClientConfiguration)
        {
            SetCredentials();
        }

        #endregion

        #region << Public methods >>

        public async Task<SocialNetworkStatus> CreateStatusAsync(string message)
        {
            var tweet = await Sync.ExecuteTaskAsync(() => Auth.ExecuteOperationWithCredentials(_credentials, () => Tweet.PublishTweet(message)));
            return mapper.Map<SocialNetworkStatus>(tweet);
        }

        #endregion

        #region << Private methods >>

        /// <summary>
        /// Sets user credentials.
        /// </summary>
        private void SetCredentials()
        {
            _credentials = Auth.SetUserCredentials(
                clientConfiguration.ConsumerKey,
                clientConfiguration.ConsumerSecret,
                clientConfiguration.AccessToken,
                clientConfiguration.AccessTokenSecret);
        }

        #endregion
    }
}
