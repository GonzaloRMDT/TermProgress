using System;
using AutoMapper;
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
        /// Mapper instance.
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// Client configuration.
        /// </summary>
        protected readonly TConfiguration clientConfiguration;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="mapper">Mapper instance.</param>
        /// <param name="clientConfiguration">Client configuration option.</param>
        public SocialNetworkClient(IMapper mapper, IOptions<TConfiguration> clientConfiguration)
        {
            this.mapper = mapper;
            this.clientConfiguration = clientConfiguration.Value;
        }
    }
}
