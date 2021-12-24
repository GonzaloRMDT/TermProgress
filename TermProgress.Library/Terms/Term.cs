using Microsoft.Extensions.Options;
using System;
using TermProgress.Library.Options;
using TermProgress.Library.Providers;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term.
    /// </summary>
    /// <inheritdoc />
    public class Term : ITerm
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IOptions<TermOptions> termOptions;

        public DateTime StartingDate { get; }
        public DateTime EndingDate { get; }
        public int ElapsedDays => (dateTimeProvider.Now.Date - StartingDate).Days;
        public int RemainingDays => (EndingDate - dateTimeProvider.Now.Date).Days;
        public int TotalDays => (EndingDate - StartingDate).Days;
        public double Progress => (double)ElapsedDays / TotalDays;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="dateTimeProvider">A <see cref="IDateTimeProvider"/> implementation.</param>
        /// <param name="termOptions">A <see cref="IOptions{T}"/> implementation with a generic type argument of <see cref="TermOptions"/>.</param>
        public Term(IDateTimeProvider dateTimeProvider, IOptions<TermOptions> termOptions)
        {
            this.dateTimeProvider = dateTimeProvider;
            this.termOptions = termOptions;
            StartingDate = this.termOptions.Value.StartingDateTime.Date;
            EndingDate = this.termOptions.Value.EndingDateTime.Date;
        }
    }
}