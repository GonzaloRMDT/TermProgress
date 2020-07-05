using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// Represents a JSON Web Token header builder.
    /// </summary>
    /// <inheritdoc />
    public class JsonWebTokenHeaderBuilder : IJsonWebTokenHeaderBuilder
    {
        #region << Fields >>

        /// <summary>
        /// Encoding.
        /// </summary>
        private Encoding _encoding;

        /// <summary>
        /// Secret key.
        /// </summary>
        private string _secretKey;

        /// <summary>
        /// Algorithm name.
        /// </summary>
        private string _algorithm;

        #endregion

        #region << Public methods >>

        public JwtHeader Build()
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(_encoding.GetBytes(_secretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, _algorithm);
            var header = new JwtHeader(signingCredentials);
            return header;
        }

        public void SetEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }

        public void SetSecretKey(string secretKey)
        {
            _secretKey = secretKey;
        }

        public void SetAlgorithm(string algorithm)
        {
            _algorithm = algorithm;
        }

        #endregion
    }
}
