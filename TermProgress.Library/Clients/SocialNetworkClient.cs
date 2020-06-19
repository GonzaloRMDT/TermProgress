using System;
using Microsoft.Extensions.Options;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Represents a social network client abstraction.
    /// </summary>
    /// <inheritdoc />
    public abstract class SocialNetworkClient<TConfiguration> where TConfiguration : class, new()
    {
        /// <summary>
        /// Client configuration.
        /// </summary>
        protected readonly TConfiguration clientConfiguration;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="clientConfiguration">Client configuration option.</param>
        public SocialNetworkClient(IOptions<TConfiguration> clientConfiguration)
        {
            this.clientConfiguration = clientConfiguration.Value;
        }
    }
}
