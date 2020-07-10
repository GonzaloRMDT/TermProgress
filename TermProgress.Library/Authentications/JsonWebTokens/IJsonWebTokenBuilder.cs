using System;
using System.Security.Claims;
using System.Text;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// <c>IJsonWebTokenBuilder</c> interface.
    /// </summary>
    public interface IJsonWebTokenBuilder : IBuilder<string>
    {
        /// <summary>
        /// Adds single claim.
        /// </summary>
        /// <param name="claim">Claim instance.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder AddClaim(Claim claim);

        /// <summary>
        /// Sets algorithm.
        /// </summary>
        /// <param name="algorithm">Algorithm name.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetAlgorithm(string algorithm);

        /// <summary>
        /// Sets audience.
        /// </summary>
        /// <param name="audience">Audience identity.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetAudience(string audience);

        /// <summary>
        /// Sets all claims.
        /// </summary>
        /// <param name="claims">Claims collection.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetClaims(Claim[] claims);

        /// <summary>
        /// Sets encoding.
        /// </summary>
        /// <param name="encoding">Encoding instance.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetEncoding(Encoding encoding);

        /// <summary>
        /// Sets token validity ending date and time.
        /// </summary>
        /// <param name="expiration">Token validity ending date and time.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetExpiration(DateTime expiration);

        /// <summary>
        /// Sets issuer identity.
        /// </summary>
        /// <param name="issuer">Issuer identity.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetIssuer(string issuer);

        /// <summary>
        /// Sets secret key.
        /// </summary>
        /// <param name="secretKey">Secret key.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetSecretKey(string secretKey);

        /// <summary>
        /// Sets token validity starting date and time.
        /// </summary>
        /// <param name="validSince">Token validity starting date and time.</param>
        /// <returns><c>JsonWebTokenBuilder</c> instance.</returns>
        JsonWebTokenBuilder SetValidSince(DateTime validSince);
    }
}