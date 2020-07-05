using System;
using System.Security.Claims;
using System.Text;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// Represents a JSON Web Token builder.
    /// </summary>
    /// <inheritdoc />
    public class JsonWebTokenBuilder : IJsonWebTokenBuilder
    {
        #region << Fields >>

        /// <summary>
        /// JSON Web Token serial builder instance.
        /// </summary>
        private readonly IJsonWebTokenSerialBuilder _serialBuilder;

        #endregion

        #region << Constructors >>

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="tokenGenerator">JSON Web Token serial builder instance.</param>
        public JsonWebTokenBuilder(IJsonWebTokenSerialBuilder serialBuilder)
        {
            _serialBuilder = serialBuilder;
        }

        #endregion

        #region << Token serial methods >>

        public string Build()
        {
            return _serialBuilder.Build();
        }

        #endregion

        #region << Token header methods >>

        public JsonWebTokenBuilder SetAlgorithm(string algorithm)
        {
            _serialBuilder.Header.SetAlgorithm(algorithm);
            return this;
        }

        public JsonWebTokenBuilder SetEncoding(Encoding encoding)
        {
            _serialBuilder.Header.SetEncoding(encoding);
            return this;
        }

        public JsonWebTokenBuilder SetSecretKey(string secretKey)
        {
            _serialBuilder.Header.SetSecretKey(secretKey);
            return this;
        }

        #endregion

        #region << Token payload methods >>

        public JsonWebTokenBuilder AddClaim(Claim claim)
        {
            _serialBuilder.Payload.AddClaim(claim);
            return this;
        }

        public JsonWebTokenBuilder SetAudience(string audience)
        {
            _serialBuilder.Payload.SetAudience(audience);
            return this;
        }

        public JsonWebTokenBuilder SetClaims(Claim[] claims)
        {
            _serialBuilder.Payload.SetClaims(claims);
            return this;
        }

        public JsonWebTokenBuilder SetExpiration(DateTime expiration)
        {
            _serialBuilder.Payload.SetExpiration(expiration);
            return this;
        }

        public JsonWebTokenBuilder SetIssuer(string issuer)
        {
            _serialBuilder.Payload.SetIssuer(issuer);
            return this;
        }

        public JsonWebTokenBuilder SetValidSince(DateTime validSince)
        {
            _serialBuilder.Payload.SetValidSince(validSince);
            return this;
        }

        #endregion
    }
}