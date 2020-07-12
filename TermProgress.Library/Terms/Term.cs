using System;
using Microsoft.Extensions.Options;
using TermProgress.Library.Configurations;
using TermProgress.Library.Providers;

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
        /// Date and time provider.
        /// </summary>
        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>
        /// Term configuration.
        /// </summary>
        private readonly TermConfiguration _termConfiguration;

        #endregion

        #region << Public methods >>

        public DateTime StartingDate { get; }

        public DateTime EndingDate { get; }

        public int ElapsedDays => (_dateTimeProvider.Now.Date - StartingDate).Days;

        public int RemainingDays => (EndingDate - _dateTimeProvider.Now.Date).Days;

        public int TotalDays => (EndingDate - StartingDate).Days;

        public double Progress => (double)ElapsedDays / TotalDays;

        #endregion

        #region << Constructor >>

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="dateTimeProvider">Date and time provider.</param>
        /// <param name="termConfiguration">Term configuration.</param>
        public Term(IDateTimeProvider dateTimeProvider, IOptions<TermConfiguration> termConfiguration)
        {
            _dateTimeProvider = dateTimeProvider;
            _termConfiguration = termConfiguration.Value;
            StartingDate = _termConfiguration.StartingDateTime.Date;
            EndingDate = StartingDate.AddYears(_termConfiguration.DurationInYears).Date;
        }

        #endregion
    }
}