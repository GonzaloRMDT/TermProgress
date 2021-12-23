namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Defines the common structure for JSON web token serial builders.
    /// </summary>
    public interface IJsonWebTokenSerialBuilder : IBuilder<string>
    {
        /// <summary>
        /// Gets a <see cref="IJsonWebTokenHeaderBuilder"/> implementation.
        /// </summary>
        IJsonWebTokenHeaderBuilder Header { get; }

        /// <summary>
        /// Gets a <see cref="IJsonWebTokenPayloadBuilder"/> implementation.
        /// </summary>
        IJsonWebTokenPayloadBuilder Payload { get; }
    }
}