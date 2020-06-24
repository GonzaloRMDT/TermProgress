using System;

namespace TermProgress.Library.Helpers
{
    /// <summary>
    /// <c>ISystemClock</c> interface.
    /// </summary>
    public interface ISystemClock
    {
        DateTime Now { get; }
    }
}
