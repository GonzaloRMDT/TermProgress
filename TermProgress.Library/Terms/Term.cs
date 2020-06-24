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
        /// Term configuration.
        /// </summary>
        private readonly TermConfiguration _termConfiguration;

        /// <summary>
        /// System clock instance.
        /// </summary>
        private readonly ISystemClock _systemClock;

        #endregion

        #region << Public methods >>

        public DateTime StartingDate { get; private set; }

        public DateTime EndingDate { get; private set; }

        public int ElapsedDays => (int)Math.Ceiling((_systemClock.Now - StartingDate).TotalDays);

        public int RemainingDays => (int)Math.Floor((EndingDate - _systemClock.Now).TotalDays);

        public int TotalDays => (int)Math.Ceiling((EndingDate - StartingDate).TotalDays);

        public double Progress => (double)ElapsedDays / TotalDays;

        #endregion

        #region << Constructor >>

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="termConfiguration">Term configuration.</param>
        /// <param name="systemClock">System clock instance.</param>
        public Term(IOptions<TermConfiguration> termConfiguration, ISystemClock systemClock)
        {
            _termConfiguration = termConfiguration.Value;
            _systemClock = systemClock;
            StartingDate = _termConfiguration.StartingDateTime;
            EndingDate = StartingDate.AddYears(_termConfiguration.DurationInYears);
        }

        #endregion
    }
}