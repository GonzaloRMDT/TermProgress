using System;
using System.ComponentModel.DataAnnotations;
using TermProgress.WebAPI.Validations;
using TermProgress.WebAPI.Validations.Enums;

namespace TermProgress.WebAPI.Dtos.Requests
{
    /// <summary>
    /// Represents a term progress status creation request.
    /// </summary>
    public record class TermProgressStatusCreationRequest
    {
        /// <summary>
        /// Gets or initializes the start date.
        /// </summary>
        [Required]
        [Comparison(Relation.LessThan, "EndDate")]
        public DateTime? StartDate { get; init; }

        /// <summary>
        /// Gets or initializes the end date.
        /// </summary>
        [Required]
        [Comparison(Relation.GreaterThan, "StartDate")]
        public DateTime? EndDate { get; init; }
    }
}
