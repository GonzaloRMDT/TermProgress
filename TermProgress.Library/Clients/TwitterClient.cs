using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TermProgress.Library.Options;
using Tweetinvi.Models;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a Twitter client.
    /// </summary>
    /// <inheritdoc/>
    public class TwitterClient : IClient<IMessage>
    {
        private Tweetinvi.TwitterClient? client;
        private readonly IOptions<TwitterClientOptions> options;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="options">An <see cref="IOptions{TOptions}"/> implementation with a generic type argument of <see cref="TwitterClientOptions"/>.</param>
        public TwitterClient(IOptions<TwitterClientOptions> options)
        {
            this.options = options;
        }

        public async Task<IMessage> CreateMessageAsync(string text)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot create message with missing client. Please set the client before calling this method.");
            }

            var response = await client!.Execute.AdvanceRequestAsync(
                (ITwitterRequest request) =>
                {
                    var jsonBody = client.Json.Serialize(new TweetV2PostRequest { Text = text });
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    request.Query.Url = "https://api.twitter.com/2/tweets";
                    request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                    request.Query.HttpContent = content;
                }
            );

            JObject responseBody = JObject.Parse(response.Response.Content);

            return GetMessage(
                responseBody["data"]["id"].ToObject<long>(),
                responseBody["data"]["text"].ToObject<string>());
        }

        public async Task DeleteMessageAsync(long id)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot delete message with missing client. Please set the client before calling this method.");
            }

            await client.Tweets.DestroyTweetAsync(id);
        }

        public async Task FavoriteMessageAsync(long id)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot favorite message with missing client. Please set the cliente before calling this method.");
            }

            await client.Tweets.FavoriteTweetAsync(id);
        }

        public async Task<IMessage> ReadMessageAsync(long id)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot read message with missing client. Please set the client before calling this method.");
            }

            ITweet message = await client.Tweets.GetTweetAsync(id);

            return GetMessage(message.Id, message.Text, message.CreatedAt.DateTime);
        }

        public void SetClient()
        {
            if (client is null)
            {
                client = new Tweetinvi.TwitterClient(
                    options.Value.ConsumerKey,
                    options.Value.ConsumerSecret,
                    options.Value.AccessToken,
                    options.Value.AccessTokenSecret);
            }
        }

        public async Task<IMessage> ShareMessageAsync(long id)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot share message with missing client. Please set the client before calling this method.");
            }

            ITweet message = await client.Tweets.PublishRetweetAsync(id);

            return GetMessage(message.Id, message.Text, message.CreatedAt.DateTime);
        }

        public async Task UnshareMessageAsync(long id)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot unshare message with missing client. Please set the client before calling this method.");
            }

            await client.Tweets.DestroyRetweetAsync(id);
        }

        public async Task UnfavoriteMessageAsync(long id)
        {
            if (client is null)
            {
                throw new InvalidOperationException("Cannot favorite message with missing client. Please set the cliente before calling this method.");
            }

            await client.Tweets.UnfavoriteTweetAsync(id);
        }

        private Message GetMessage(long id, string text, DateTime? createdAt = null)
        {
            return new Message()
            {
                Id = id,
                Text = text,
                CreatedAt = createdAt ?? DateTime.Now,
                Network = GetType().Name.Replace("Client", null, StringComparison.OrdinalIgnoreCase)
            };
        }

        private class TweetV2PostRequest
        {
            /// <summary>
            /// The text of the tweet to post.
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; } = string.Empty;
        }
    }
}
