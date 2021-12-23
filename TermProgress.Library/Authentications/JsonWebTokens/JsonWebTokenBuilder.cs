using System;
using System.Security.Claims;
using System.Text;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Represents a JSON Web Token builder.
    /// </summary>
    /// <inheritdoc />
    public class JsonWebTokenBuilder : IJsonWebTokenBuilder
    {
        private readonly IJsonWebTokenSerialBuilder serialBuilder;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="serialBuilder">A <see cref="IJsonWebTokenSerialBuilder"/> implementation.</param>
        public JsonWebTokenBuilder(IJsonWebTokenSerialBuilder serialBuilder)
        {
            this.serialBuilder = serialBuilder;
        }
        
        public string Build()
        {
            return serialBuilder.Build();
        }

        public JsonWebTokenBuilder SetAlgorithm(string algorithm)
        {
            serialBuilder.Header.SetAlgorithm(algorithm);
            return this;
        }

        public JsonWebTokenBuilder SetEncoding(Encoding encoding)
        {
            serialBuilder.Header.SetEncoding(encoding);
            return this;
        }

        public JsonWebTokenBuilder SetSecretKey(string secretKey)
        {
            serialBuilder.Header.SetSecretKey(secretKey);
            return this;
        }

        public JsonWebTokenBuilder AddClaim(Claim claim)
        {
            serialBuilder.Payload.AddClaim(claim);
            return this;
        }

        public JsonWebTokenBuilder SetAudience(string audience)
        {
            serialBuilder.Payload.SetAudience(audience);
            return this;
        }

        public JsonWebTokenBuilder SetClaims(Claim[] claims)
        {
            serialBuilder.Payload.SetClaims(claims);
            return this;
        }

        public JsonWebTokenBuilder SetExpiration(DateTime expiration)
        {
            serialBuilder.Payload.SetExpiration(expiration);
            return this;
        }

        public JsonWebTokenBuilder SetIssuer(string issuer)
        {
            serialBuilder.Payload.SetIssuer(issuer);
            return this;
        }

        public JsonWebTokenBuilder SetValidSince(DateTime validSince)
        {
            serialBuilder.Payload.SetValidSince(validSince);
            return this;
        }
    }
}