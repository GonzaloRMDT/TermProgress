using System;
using Microsoft.Extensions.Options;
using TermProgress.Library.Configurations;
using TermProgress.Library.Helpers;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term.
    /// </summary>
    /// <inheritdoc />
    public class Term : ITerm
    {
        #region << Private fields >>

        /// <summary>
        /// System clock instance.
        /// </summary>
        private readonly ISystemClock _systemClock;

        /// <summary>
        /// Term configuration.
        /// </summary>
        private readonly TermConfiguration _termConfiguration;

        #endregion

        #region << Public methods >>

        public DateTime StartingDate { get; }

        public DateTime EndingDate { get; }

        public int ElapsedDays => (_systemClock.Now.Date - StartingDate).Days;

        public int RemainingDays => (EndingDate - _systemClock.Now.Date).Days;

        public int TotalDays => (EndingDate - StartingDate).Days;

        public double Progress => (double)ElapsedDays / TotalDays;

        #endregion

        #region << Constructor >>

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="systemClock">System clock instance.</param>
        /// <param name="termConfiguration">Term configuration.</param>
        public Term(ISystemClock systemClock, IOptions<TermConfiguration> termConfiguration)
        {
            _systemClock = systemClock;
            _termConfiguration = termConfiguration.Value;
            StartingDate = _termConfiguration.StartingDateTime.Date;
            EndingDate = StartingDate.AddYears(_termConfiguration.DurationInYears).Date;
        }

        #endregion
    }
}