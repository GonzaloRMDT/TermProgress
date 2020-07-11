using System;

namespace TermProgress.Worker.Configurations
{
    /// <summary>
    /// Represents the application configuration.
    /// </summary>
    public class ApplicationConfiguration
    {
        /// <summary>
        /// Application admin username.
        /// </summary>
        public string ApplicationAdminUsername { get; set; }

        /// <summary>
        /// Application admin password.
        /// </summary>
        public string ApplicationAdminPassword { get; set; }

        /// <summary>
        /// Application authentication endpoint URL.
        /// </summary>
        public string ApplicationAuthenticationEndpointUrl { get; set; }

        /// <summary>
        /// Twitter status creation endpoint URL.
        /// </summary>
        public string TwitterStatusCreationEndpointUrl { get; set; }
    }
}
