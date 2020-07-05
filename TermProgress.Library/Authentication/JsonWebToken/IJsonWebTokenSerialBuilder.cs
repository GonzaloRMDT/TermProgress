using System;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// <c>IJsonWebTokenSerialBuilder</c> interface.
    /// </summary>
    public interface IJsonWebTokenSerialBuilder : IBuilder<string>
    {
        /// <summary>
        /// Gets the JSON Web Token header builder instance.
        /// </summary>
        IJsonWebTokenHeaderBuilder Header { get; }

        /// <summary>
        /// Gets the JSON Web Token payload builder instance.
        /// </summary>
        IJsonWebTokenPayloadBuilder Payload { get; }
    }
}