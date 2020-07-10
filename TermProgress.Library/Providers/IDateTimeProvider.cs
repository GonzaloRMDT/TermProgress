using System;

namespace TermProgress.Library.Providers
{
    /// <summary>
    /// <c>IDateTimeProvider</c> interface.
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
