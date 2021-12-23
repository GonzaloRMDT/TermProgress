using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Represents a JSON Web Token header builder.
    /// </summary>
    /// <inheritdoc />
    public class JsonWebTokenHeaderBuilder : IJsonWebTokenHeaderBuilder
    {
        private Encoding encoding;
        private string secretKey;
        private string algorithm;

        public JwtHeader Build()
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(encoding.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, algorithm);
            var header = new JwtHeader(signingCredentials);
            return header;
        }

        public void SetEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public void SetSecretKey(string secretKey)
        {
            this.secretKey = secretKey;
        }

        public void SetAlgorithm(string algorithm)
        {
            this.algorithm = algorithm;
        }
    }
}
