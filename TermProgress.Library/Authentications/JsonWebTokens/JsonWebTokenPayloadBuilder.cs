using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Represents a JSON Web Token payload builder.
    /// </summary>
    /// <inheritdoc />
    public class JsonWebTokenPayloadBuilder : IJsonWebTokenPayloadBuilder
    {
        #region << Fields >>

        /// <summary>
        /// Issuer identity.
        /// </summary>
        private string _issuer;

        /// <summary>
        /// Audience identity.
        /// </summary>
        private string _audience;

        /// <summary>
        /// Token validation starting date and time.
        /// </summary>
        private DateTime _validSince;

        /// <summary>
        /// Token validation ending date and time.
        /// </summary>
        private DateTime _expiration;

        /// <summary>
        /// Claims collection.
        /// </summary>
        private List<Claim> _claims = new List<Claim>();

        #endregion

        #region << Public methods >>

        public JwtPayload Build()
        {
            return new JwtPayload(
                issuer: _issuer,
                audience: _audience,
                claims: _claims,
                notBefore: _validSince,
                expires: _expiration);
        }

        public void AddClaim(Claim claim)
        {
            _claims.Add(claim);
        }

        public void SetAudience(string audience)
        {
            _audience = audience;
        }

        public void SetClaims(Claim[] claims)
        {
            _claims = new List<Claim>(claims);
        }

        public void SetExpiration(DateTime expiration)
        {
            _expiration = expiration;
        }

        public void SetIssuer(string issuer)
        {
            _issuer = issuer;
        }

        public void SetValidSince(DateTime validSince)
        {
            _validSince = validSince;
        }

        #endregion
    }
}
