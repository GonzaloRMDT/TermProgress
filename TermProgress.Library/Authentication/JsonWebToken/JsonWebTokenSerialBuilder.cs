using System;
using System.IdentityModel.Tokens.Jwt;

namespace TermProgress.Library.Authentication.JsonWebToken
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
        /// <param name="headerBuilder">JSON Web Token header builder instance.</param>
        /// <param name="payloadBuilder">JSON Web Token payload builder instance.</param>
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