using Microsoft.Extensions.Options;
using System;
using TermProgress.Library.Options;

namespace TermProgress.Library.Terms
{
    /// <summary>
    /// Represents a term.
    /// </summary>
    public class Term : ITerm
    {
        private readonly IOptions<TermOptions> termOptions;
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="termOptions">A <see cref="IOptions{T}"/> implementation with a generic type argument of <see cref="TermOptions"/>.</param>
        public Term(IOptions<TermOptions> termOptions)
        {
            this.termOptions = termOptions;
        }

        /// <inheritdoc/>
        /// <remarks>
        /// If this property has been set to a specific date, gets said specific date. Else, returns the actual date.
        /// </remarks>
        public DateTime? CurrentDate
        {
            get
            {
                return currentDate ?? DateTime.Now.Date;
            }
            set
            {
                currentDate = value?.Date;
            }
        }
        private DateTime? currentDate;

        public int? ElapsedDays => (CurrentDate - StartingDate)?.Days;
        
        public DateTime? EndingDate => termOptions.Value.EndingDate.Date;
        
        public double? Progress => (double)(ElapsedDays ?? 0) / TotalDays;
        
        public int? RemainingDays => (EndingDate - CurrentDate)?.Days;
        
        public DateTime? StartingDate => termOptions.Value.StartingDate.Date;
        
        public int? TotalDays => (EndingDate - StartingDate)?.Days;
    }
}
