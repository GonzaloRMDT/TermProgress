using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// <c>IJsonWebTokenPayloadBuilder</c> interface.
    /// </summary>
    public interface IJsonWebTokenPayloadBuilder: IBuilder<JwtPayload>
    {
        /// <summary>
        /// Adds single claim.
        /// </summary>
        /// <param name="claim">Claim instance.</param>
        void AddClaim(Claim claim);

        /// <summary>
        /// Sets audience identity.
        /// </summary>
        /// <param name="audience">Audience identity.</param>
        void SetAudience(string audience);

        /// <summary>
        /// Sets claims.
        /// </summary>
        /// <param name="claims">Claims collection.</param>
        void SetClaims(Claim[] claims);

        /// <summary>
        /// Sets token validity ending date and time.
        /// </summary>
        /// <param name="expiration">Token validity ending date and time.</param>
        void SetExpiration(DateTime expiration);

        /// <summary>
        /// Sets issuer identity.
        /// </summary>
        /// <param name="issuer">Issuer identity.</param>
        void SetIssuer(string issuer);

        /// <summary>
        /// Sets token validity starting date and time.
        /// </summary>
        /// <param name="validSince">Token validity starting date and time.</param>
        void SetValidSince(DateTime validSince);
    }
}