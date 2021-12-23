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
        private string issuer;
        private string audience;
        private DateTime validSince;
        private DateTime expiration;
        private List<Claim> claims = new List<Claim>();

        public JwtPayload Build()
        {
            return new JwtPayload(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: validSince,
                expires: expiration);
        }

        public void AddClaim(Claim claim)
        {
            claims.Add(claim);
        }

        public void SetAudience(string audience)
        {
            this.audience = audience;
        }

        public void SetClaims(Claim[] claims)
        {
            this.claims = new List<Claim>(claims);
        }

        public void SetExpiration(DateTime expiration)
        {
            this.expiration = expiration;
        }

        public void SetIssuer(string issuer)
        {
            this.issuer = issuer;
        }

        public void SetValidSince(DateTime validSince)
        {
            this.validSince = validSince;
        }
    }
}
