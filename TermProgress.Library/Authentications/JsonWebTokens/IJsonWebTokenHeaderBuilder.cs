﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Defines the common structure for JSON web token header builders.
    /// </summary>
    public interface IJsonWebTokenHeaderBuilder : IBuilder<JwtHeader>
    {
        /// <summary>
        /// Sets algorithm.
        /// </summary>
        /// <param name="algorithm">Algorithm name.</param>
        void SetAlgorithm(string algorithm);

        /// <summary>
        /// Sets encoding.
        /// </summary>
        /// <param name="encoding">An <see cref="Encoding"/> instance.</param>
        void SetEncoding(Encoding encoding);

        /// <summary>
        /// Sets secret key.
        /// </summary>
        /// <param name="secretKey">Secret key.</param>
        void SetSecretKey(string secretKey);
    }
}