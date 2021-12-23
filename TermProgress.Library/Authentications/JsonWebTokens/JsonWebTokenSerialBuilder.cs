using System.IdentityModel.Tokens.Jwt;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Represents a JSON web token serial builder.
    /// </summary>
    /// <inheritdoc />
    public class JsonWebTokenSerialBuilder : IJsonWebTokenSerialBuilder
    {
        public IJsonWebTokenHeaderBuilder Header { get; }
        public IJsonWebTokenPayloadBuilder Payload { get; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="headerBuilder">A <see cref="IJsonWebTokenHeaderBuilder"/> implementation.</param>
        /// <param name="payloadBuilder">A <see cref="IJsonWebTokenPayloadBuilder"/> implementation.</param>
        public JsonWebTokenSerialBuilder(IJsonWebTokenHeaderBuilder headerBuilder, IJsonWebTokenPayloadBuilder payloadBuilder)
        {
            Header = headerBuilder;
            Payload = payloadBuilder;
        }

        public string Build()
        {
            var token = new JwtSecurityToken(Header.Build(), Payload.Build());
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}