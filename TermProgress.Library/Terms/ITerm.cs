using System;

namespace TermProgress.Library.Terms
{
    public interface ITerm
    {
        /// <summary>
        /// Term starting date.
        /// </summary>
        DateTime StartingDate { get; }

        /// <summary>
        /// Term ending date.
        /// </summary>
        DateTime EndingDate { get; }

        /// <summary>
        /// Term total days.
        /// </summary>
        int TotalDays { get; }

        /// <summary>
        /// Term elapsed days.
        /// </summary>
        int ElapsedDays { get; }

        /// <summary>
        /// Term remaining days.
        /// </summary>
        int RemainingDays { get; }

        /// <summary>
        /// Term progress.
        /// </summary>
        double Progress { get; }
    }
}