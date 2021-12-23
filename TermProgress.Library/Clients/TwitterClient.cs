using AutoMapper;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TermProgress.Library.Options;
using Tweetinvi;
using Tweetinvi.Models;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a Twitter client.
    /// </summary>
    /// <inheritdoc />
    public class TwitterClient : SocialNetworkClient<TwitterClientOptions>, IClient
    {
        private ITwitterCredentials credentials;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="mapper">A <see cref="IMapper"/> implementation.</param>
        /// <param name="twitterClientOptions">A <see cref="IOptions{T}"/> implementation with a generic type argument of <see cref="TwitterClientOptions"/>.</param>
        public TwitterClient(IMapper mapper, IOptions<TwitterClientOptions> twitterClientOptions) : base(mapper, twitterClientOptions)
        {
            SetCredentials();
        }

        public async Task<SocialNetworkStatus> CreateStatusAsync(string message)
        {
            var tweet = await Sync.ExecuteTaskAsync(() => Auth.ExecuteOperationWithCredentials(credentials, () => Tweet.PublishTweet(message)));
            return mapper.Map<SocialNetworkStatus>(tweet);
        }

        /// <summary>
        /// Sets user credentials.
        /// </summary>
        private void SetCredentials()
        {
            credentials = Auth.SetUserCredentials(
                clientConfiguration.ConsumerKey,
                clientConfiguration.ConsumerSecret,
                clientConfiguration.AccessToken,
                clientConfiguration.AccessTokenSecret);
        }
    }
}
