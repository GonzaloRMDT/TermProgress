using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TermProgress.Library.Options;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Represents a token validation parameters factory.
    /// </summary>
    /// <inheritdoc />
    public class TokenValidationParametersFactory : ITokenValidationParametersFactory
    {
        private readonly IMapper mapper;
        private readonly IOptions<TokenOptions> tokenOptions;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="mapper">A mapper implementation.</param>
        /// <param name="tokenOptions">An <see cref="IOptions{T}"/> implementation with a generic type argument of <see cref="TokenOptions"/></param>
        public TokenValidationParametersFactory(IMapper mapper, IOptions<TokenOptions> tokenOptions)
        {
            this.mapper = mapper;
            this.tokenOptions = tokenOptions;
        }

        public TokenValidationParameters Create()
        {
            return mapper.Map<TokenValidationParameters>(tokenOptions);
        }
    }
}
