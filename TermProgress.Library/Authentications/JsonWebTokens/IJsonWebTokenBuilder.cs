using System;
using System.Security.Claims;
using System.Text;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Defines the common structure for JSON web token builders.
    /// </summary>
    /// <remarks>
    /// This interface defines a fluent interface, where methods can be called as a chain.
    /// </remarks>
    public interface IJsonWebTokenBuilder : IBuilder<string>
    {
        /// <summary>
        /// Adds single claim.
        /// </summary>
        /// <param name="claim">A <see cref="Claim"/> instance.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder AddClaim(Claim claim);

        /// <summary>
        /// Sets algorithm.
        /// </summary>
        /// <param name="algorithm">Algorithm name.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder SetAlgorithm(string algorithm);

        /// <summary>
        /// Sets audience.
        /// </summary>
        /// <param name="audience">Audience identity.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder SetAudience(string audience);

        /// <summary>
        /// Sets all claims.
        /// </summary>
        /// <param name="claims">An <see cref="Array"/> of <see cref="Claim"/>.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder SetClaims(Claim[] claims);

        /// <summary>
        /// Sets encoding.
        /// </summary>
        /// <param name="encoding">An <see cref="Encoding"/> instance.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder SetEncoding(Encoding encoding);

        /// <summary>
        /// Sets token validity ending date and time.
        /// </summary>
        /// <param name="expiration">Token validity ending date and time.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder SetExpiration(DateTime expiration);

        /// <summary>
        /// Sets issuer identity.
        /// </summary>
        /// <param name="issuer">Issuer identity.</param>
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
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
        /// <returns>A <see cref="JsonWebTokenBuilder"/> instance.</returns>
        JsonWebTokenBuilder SetValidSince(DateTime validSince);
    }
}