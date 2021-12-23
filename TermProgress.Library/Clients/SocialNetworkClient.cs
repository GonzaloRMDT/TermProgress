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
        protected readonly IMapper mapper;
        protected readonly TConfiguration clientConfiguration;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="mapper">A <see cref="IMapper"/> implementation..</param>
        /// <param name="clientConfiguration">A <see cref="IOptions{T}"/> with a generic type argument of <see cref="TConfiguration"/>.</param>
        public SocialNetworkClient(IMapper mapper, IOptions<TConfiguration> clientConfiguration)
        {
            this.mapper = mapper;
            this.clientConfiguration = clientConfiguration.Value;
        }
    }
}
