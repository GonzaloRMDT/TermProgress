using System;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Defines the common structure for builders.
    /// </summary>
    /// <typeparam name="T">Buildable element of type <see cref="T"/>.</typeparam>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Builds element of type <see cref="T"/>.
        /// </summary>
        /// <returns>Built element of type <see cref="T"/>.</returns>
        T Build();
    }
}