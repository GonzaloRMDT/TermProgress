using System;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// <c>IBuilder</c> interface.
    /// </summary>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Builds element of type T.
        /// </summary>
        /// <returns>Built element of type T.</returns>
        T Build();
    }
}