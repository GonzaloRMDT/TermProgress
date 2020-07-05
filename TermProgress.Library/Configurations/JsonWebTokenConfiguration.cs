using System;

namespace TermProgress.Library.Configurations
{
    /// <summary>
    /// Represents the JSON Web Token configuration.
    /// </summary>
    public class JsonWebTokenConfiguration
    {
        /// <summary>
        /// Gets or sets the intended audience of the JSON web token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the issuer of the JSON web token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the secret key used to create the signature of the JSON web token.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets the token lifetime.
        /// </summary>
        public TimeSpan TokenLifetime { get; set; }

        /// <summary>
        /// Gets or sets whether audience should be validated.
        /// </summary>
        public bool ValidateAudience { get; set; }

        /// <summary>
        /// Gets or sets whether the issuer should be validated.
        /// </summary>
        public bool ValidateIssuer { get; set; }

        /// <summary>
        /// Gets or sets whether isser signing key should be validated.
        /// </summary>
        public bool ValidateIssuerSigningKey { get; set; }


        /// <summary>
        /// Gets or sets whether token lifetime should be validated.
        /// </summary>
        public bool ValidateLifeTime { get; set; }

    }
}
