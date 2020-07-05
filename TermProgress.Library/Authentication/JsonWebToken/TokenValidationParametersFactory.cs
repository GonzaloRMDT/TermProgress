using System;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TermProgress.Library.Configurations;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// Represente a <c>TokenValidationParameters</c> factory.
    /// </summary>
    /// <inheritdoc />
    public class TokenValidationParametersFactory : ITokenValidationParametersFactory
    {
        /// <summary>
        /// Mapper instance.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Json Web Token configuration.
        /// </summary>
        private readonly JsonWebTokenConfiguration _jsonWebTokenConfiguration;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="mapper">Mapper instance.</param>
        /// <param name="jsonWebTokenConfiguration">Json Web Token configuration.</param>
        public TokenValidationParametersFactory(IMapper mapper, IOptions<JsonWebTokenConfiguration> jsonWebTokenConfiguration)
        {
            _mapper = mapper;
            _jsonWebTokenConfiguration = jsonWebTokenConfiguration.Value;
        }

        public TokenValidationParameters Create()
        {
            return _mapper.Map<TokenValidationParameters>(_jsonWebTokenConfiguration);
        }
    }
}
