using Microsoft.Extensions.Options;
using System;
using System.Text;
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

        public int ElapsedDays => (DateTime.Now.Date - StartingDate).Days;
        
        public DateTime EndingDate => termOptions.Value.EndingDateTime.Date;
        
        public double Progress => (double)ElapsedDays / TotalDays;
        
        public int RemainingDays => (EndingDate - DateTime.Now.Date).Days;
        
        public DateTime StartingDate => termOptions.Value.StartingDateTime.Date;
        
        public int TotalDays => (EndingDate - StartingDate).Days;

    }
}
